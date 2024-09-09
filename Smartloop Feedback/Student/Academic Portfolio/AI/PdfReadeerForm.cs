using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Chat;

namespace Smartloop_Feedback.Academic_Portfolio.AI
{
    public partial class PdfReadeerForm : Form
    {
        private readonly string apiKey = ConfigurationManager.AppSettings["OpenAi_Apikey"];
        private OpenAIAPI api;

        public PdfReadeerForm()
        {
            InitializeComponent();
            api = new OpenAIAPI(apiKey);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private async void btnUploadFile_Click(object sender, EventArgs e)
        {
            string assessmentDocument = ExtractTextFromPdf(txtFilePath.Text);
            string teacherComments = txtComments.Text;
            string rubric = txtRubric.Text;

            try
            {
                var feedbackResult = await GetFeedbackFromAI(assessmentDocument, teacherComments, rubric);

                if (feedbackResult != null)
                {
                    // Assign the parsed sections to the corresponding text boxes
                    txtGrade.Text = feedbackResult.Grade.Trim();
                    txtFeedback.Text = feedbackResult.Feedback.Trim();
                    txtnextStep.Text = feedbackResult.NextStep.Trim();
                }
                else
                {
                    MessageBox.Show("No feedback received. Please check the response and try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private string ExtractTextFromPdf(string filePath)
        {
            StringBuilder text = new StringBuilder();

            using (PdfReader reader = new PdfReader(filePath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }

            return text.ToString();
        }

        private async Task<FeedbackResultTest> GetFeedbackFromAI(string assessmentDocument, string teacherComments, string rubric)
        {
            var conversation = api.Chat.CreateConversation();

            // Append system message
            conversation.AppendMessage(ChatMessageRole.System, "You are an intelligent and empathetic educational assistant. Your goal is to help students improve by providing personalized feedback based on their assessment, teacher's comments, and the rubric provided. Your feedback should be constructive, encouraging, and specific, referencing direct quotes from the assessment document where applicable.");

            // Append user messages
            conversation.AppendMessage(ChatMessageRole.User, $"Please review the following assessment document, teacher's comments, and rubric. Provide a grade, personalized feedback to the student, and suggestions for improvement. Use quotes from the assessment document itself to make your feedback more impactful.");
            conversation.AppendMessage(ChatMessageRole.User, $"Additionally, please provide detailed next steps for the student on how to improve their work. Specify which sections or parts of the assessment need the most attention, what changes should be made, and any additional resources or strategies that could help enhance their submission.");
            conversation.AppendMessage(ChatMessageRole.User, $"Please divide your response into three sections titled 'Grade', 'Feedback', and 'Next Steps'.");
            conversation.AppendMessage(ChatMessageRole.User, $"Assessment Document: {assessmentDocument}, Teacher's Comments: {teacherComments}, Rubric: {rubric}");

            // Get the response from the AI
            string response = await conversation.GetResponseFromChatbotAsync();

            Console.WriteLine("Raw API Response:");
            Console.WriteLine(response);

            // Parse the response into sections
            var feedbackResult = ParseResponseIntoSections(response);

            return feedbackResult;
        }

        private FeedbackResultTest ParseResponseIntoSections(string response)
        {
            var feedbackResult = new FeedbackResultTest();

            try
            {
                // Split the response into sections by looking for the specific section titles
                feedbackResult.Grade = ExtractSection(response, "Grade:");
                feedbackResult.Feedback = ExtractSection(response, "Feedback:");
                feedbackResult.NextStep = ExtractSection(response, "Next Steps:");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing response into sections: {ex.Message}");
            }

            return feedbackResult;
        }

        private string ExtractSection(string response, string sectionTitle)
        {
            var startIndex = response.IndexOf(sectionTitle, StringComparison.OrdinalIgnoreCase);

            if (startIndex == -1)
            {
                return $"No {sectionTitle} section found.";
            }

            startIndex += sectionTitle.Length;
            var endIndex = response.IndexOf("###", startIndex);

            if (endIndex == -1) endIndex = response.Length;

            var sectionContent = response.Substring(startIndex, endIndex - startIndex).Trim();

            return sectionContent;
        }
    }

    public class FeedbackResultTest
    {
        public string Grade { get; set; }
        public string Feedback { get; set; }
        public string NextStep { get; set; }
    }
}
