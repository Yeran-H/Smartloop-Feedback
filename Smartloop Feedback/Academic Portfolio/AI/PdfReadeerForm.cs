using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using OpenAI_API;
using OpenAI_API.Chat;

namespace Smartloop_Feedback.Academic_Portfolio.AI
{
    public partial class PdfReadeerForm : Form
    {
        private readonly string apiKey = ConfigurationManager.AppSettings["OpenAi_Apikey"];
        private OpenAIAPI api;
        private List<ChatMessage> conversationHistory;

        public PdfReadeerForm()
        {
            InitializeComponent();
            api = new OpenAIAPI(apiKey);
            conversationHistory = new List<ChatMessage>();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private async void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text))
            {
                string fileId = await UploadFile(txtFilePath.Text);
                if (!string.IsNullOrEmpty(fileId))
                {
                    await ProvideFeedback(fileId, txtComments.Text, txtRubric.Text);
                }
            }
            else
            {
                MessageBox.Show("Please select a file first.");
            }
        }

        private async Task<string> UploadFile(string filePath)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                MultipartFormDataContent form = new MultipartFormDataContent();
                ByteArrayContent fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filePath));
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/pdf");
                form.Add(fileContent, "file", Path.GetFileName(filePath));
                form.Add(new StringContent("fine-tune"), "purpose");

                try
                {
                    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/files", form);
                    string responseContent = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("File uploaded successfully.");
                        var responseJson = JObject.Parse(responseContent);
                        return responseJson["id"]?.ToString();
                    }
                    else
                    {
                        MessageBox.Show($"File upload failed. Status code: {response.StatusCode}, Response: {responseContent}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                    return null;
                }
            }
        }

        private async Task<string> RetrieveFileContent(string fileId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://api.openai.com/v1/files/{fileId}/content");
                    if (response.IsSuccessStatusCode)
                    {
                        string fileContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("File retrieved successfully.");
                        return fileContent;
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to retrieve file. Status code: {response.StatusCode}, Response: {responseContent}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                    return null;
                }
            }
        }

        private async Task<string> SummarizeContent(string content)
        {
            var summarizePrompt = $"Summarize the following content in 200 words: {content}";

            var summarizeRequest = new ChatRequest()
            {
                Model = "gpt-3.5-turbo",
                Messages = new List<ChatMessage>
                {
                    new ChatMessage
                    {
                        Role = ChatMessageRole.User,
                        TextContent = summarizePrompt
                    }
                },
                Temperature = 0.3,
                MaxTokens = 1500
            };

            var result = await api.Chat.CreateChatCompletionAsync(summarizeRequest);
            return result.Choices[0].Message.TextContent.Trim();
        }

        private async Task ProvideFeedback(string fileId, string comments, string rubric)
        {
            try
            {
                string fileContent = await RetrieveFileContent(fileId);

                if (string.IsNullOrEmpty(fileContent))
                {
                    MessageBox.Show("File content is empty. Cannot provide feedback.");
                    return;
                }

                string summarizedContent = await SummarizeContent(fileContent);

                var prompt = $@"
You are an intelligent and empathetic assistant designed to help students improve their academic performance. You will receive an assessment task, previous teacher comments, a rubric, and subject information. Your job is to provide detailed, personalized feedback including a grade, feedback, and tips for improvement. Do not just reword teacher comments; instead, create unique and actionable advice.

Input Data:
- Assessment Task: {summarizedContent}
- Previous Teacher Comments: {comments}
- Rubric: {rubric}
- Subject Information: [Provide any necessary subject information here]

Output: Personalized Dynamic Feedback

---

**Assessment Task:** {Path.GetFileName(txtFilePath.Text)}

**Subject:** [Provide the subject name here]

---

### Feedback Overview

**Grade:**
Provide a grade based on the assessment task and rubric criteria.

**Task Analysis:**

*Quote:* ""Understanding the core of your assessment is crucial for success.""

Based on the given task, you are required to {{brief summary of the task}}. To excel in this task, focus on the following key areas:

1. **{{Key Area 1}}**: {{Detailed explanation on how to approach this area}}.
2. **{{Key Area 2}}**: {{Detailed explanation on how to approach this area}}.
3. **{{Key Area 3}}**: {{Detailed explanation on how to approach this area}}.

**Rubric Breakdown:**

*Quote:* ""Aligning your work with the rubric criteria can significantly improve your grades.""

The rubric emphasizes the following aspects:

- **Criterion 1: {{Criterion Title}}**
  - *What it means:* {{Explanation of the criterion}}.
  - *How to achieve it:* {{Specific strategies to meet this criterion}}.

- **Criterion 2: {{Criterion Title}}**
  - *What it means:* {{Explanation of the criterion}}.
  - *How to achieve it:* {{Specific strategies to meet this criterion}}.

- **Criterion 3: {{Criterion Title}}**
  - *What it means:* {{Explanation of the criterion}}.
  - *How to achieve it:* {{Specific strategies to meet this criterion}}.

**Previous Teacher Comments:**

*Quote:* ""Feedback is the bridge between instruction and improvement.""

Your previous teacher mentioned {{summarize key comments}}. Here’s how you can address each point:

- **Comment 1: {{Comment Summary}}**
  - *Feedback:* {{Personalized advice based on the comment}}.

- **Comment 2: {{Comment Summary}}**
  - *Feedback:* {{Personalized advice based on the comment}}.

- **Comment 3: {{Comment Summary}}**
  - *Feedback:* {{Personalized advice based on the comment}}.

### Detailed Feedback

**Introduction:**

*Quote:* ""A strong introduction sets the tone for the entire assessment.""

- **Current Performance:** {{Assessment of the current introduction based on rubric and teacher comments}}.
- **Improvement Suggestions:** {{Specific steps to improve the introduction}}.

**Body:**

*Quote:* ""Clarity and coherence in the body make your arguments persuasive.""

- **Current Performance:** {{Assessment of the current body based on rubric and teacher comments}}.
- **Improvement Suggestions:** {{Specific steps to enhance the body of the assessment}}.

**Conclusion:**

*Quote:* ""A compelling conclusion reinforces your main points and leaves a lasting impression.""

- **Current Performance:** {{Assessment of the current conclusion based on rubric and teacher comments}}.
- **Improvement Suggestions:** {{Specific steps to strengthen the conclusion}}.

### Tips for Improvement

*Quote:* ""Utilizing available resources can elevate the quality of your work.""

- **Tip 1: {{Tip Title}}**
  - *Description:* {{Brief description of the tip}}.
  - *How to apply it:* {{Instructions on how to effectively use the tip}}.

- **Tip 2: {{Tip Title}}**
  - *Description:* {{Brief description of the tip}}.
  - *How to apply it:* {{Instructions on how to effectively use the tip}}.

---

By focusing on these personalized suggestions, you can significantly improve your performance on the {Path.GetFileName(txtFilePath.Text)}. Remember to align your work with the rubric and utilize the feedback provided to address specific areas for improvement. Good luck!
                ";

                var initialMessage = new ChatMessage
                {
                    Role = ChatMessageRole.User,
                    TextContent = prompt
                };
                conversationHistory.Add(initialMessage);

                var chatRequest = new ChatRequest()
                {
                    Model = "gpt-3.5-turbo",
                    Messages = conversationHistory,
                    Temperature = 0.3,
                    MaxTokens = 1500
                };

                var result = await api.Chat.CreateChatCompletionAsync(chatRequest);
                var response = result.Choices[0].Message.TextContent;

                conversationHistory.Add(result.Choices[0].Message);

                var gradeMarker = "Grade:";
                var feedbackMarker = "Feedback:";
                var tipsMarker = "Tips for Improvement:";

                var gradeIndex = response.IndexOf(gradeMarker);
                var feedbackIndex = response.IndexOf(feedbackMarker);
                var tipsIndex = response.IndexOf(tipsMarker);

                if (gradeIndex >= 0 && feedbackIndex >= 0 && tipsIndex >= 0)
                {
                    var grade = response.Substring(gradeIndex + gradeMarker.Length, feedbackIndex - gradeIndex - gradeMarker.Length).Trim();
                    var feedback = response.Substring(feedbackIndex + feedbackMarker.Length, tipsIndex - feedbackIndex - feedbackMarker.Length).Trim();
                    var tips = response.Substring(tipsIndex + tipsMarker.Length).Trim();

                    txtGrade.Text = grade;
                    txtFeedback.Text = feedback;
                    txtTips.Text = tips;
                }
                else
                {
                    txtGrade.Text = "Could not parse the response.";
                    txtFeedback.Text = response;
                    txtTips.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnSendQuestion_Click(object sender, EventArgs e)
        {
            var question = txtUserQuestion.Text;

            if (string.IsNullOrEmpty(question))
            {
                MessageBox.Show("Please enter a question.");
                return;
            }

            try
            {
                var prompt = $"Follow-up question based on the feedback provided: {question}";

                var userQuestionMessage = new ChatMessage
                {
                    Role = ChatMessageRole.User,
                    TextContent = prompt
                };
                conversationHistory.Add(userQuestionMessage);

                var chatRequest = new ChatRequest()
                {
                    Model = "gpt-3.5-turbo",
                    Messages = conversationHistory,
                    Temperature = 0.3,
                    MaxTokens = 500
                };

                var result = await api.Chat.CreateChatCompletionAsync(chatRequest);
                var response = result.Choices[0].Message.TextContent;

                conversationHistory.Add(result.Choices[0].Message);

                txtAIResponse.Text = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
