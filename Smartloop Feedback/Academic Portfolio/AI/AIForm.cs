using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using OpenAI_API;
using OpenAI_API.Chat;
using Smartloop_Feedback.Objects;

namespace Smartloop_Feedback.Academic_Portfolio.AI
{
    public partial class AIForm : Form
    {
        private readonly string apiKey = ConfigurationManager.AppSettings["OpenAi_Apikey"];
        private OpenAIAPI api;
        public Assessment assessment;
        public MainForm mainForm;

        public AIForm(Assessment assessment, MainForm mainForm)
        {
            InitializeComponent();
            api = new OpenAIAPI(apiKey);
            this.mainForm = mainForm;
            this.assessment = assessment;
        }


        private void AIForm_Load(object sender, EventArgs e)
        {
            foreach (FeedbackResult feedbackResult in assessment.FeedbackList.Values)
            {
                previousCb.Items.Add(feedbackResult.Attempt + " Mark: " + feedbackResult.Grade);
            }
        }

        private void loadAssessmentBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileTb.Text = openFileDialog.FileName;
            }
        }

        private async void feedbackBtn_Click(object sender, EventArgs e)
        {
            string assessmentDocument = ExtractTextFromPdf(fileTb.Text);
            string teacherComments = teacherRb.Text;
            string rubric = ExtractTextFromRubric().ToString();
            string note = noteRb.Text;
            double totalMarks = assessment.Mark;

            try
            {
                FeedbackResult feedbackResult = await GetFeedbackFromAI(assessmentDocument, teacherComments, rubric, note, totalMarks);

                if (feedbackResult != null)
                {
                    // Assign the parsed sections to the corresponding text boxes
                    markTb.Text = feedbackResult.Grade;
                    feedbackRb.Text = feedbackResult.Feedback;
                    nextRb.Text = feedbackResult.NextStep;

                    feedbackResult.FileName = fileTb.Text;
                    feedbackResult.FileData = Encoding.UTF8.GetBytes(assessmentDocument);

                    // Display the ratings for each criterion in the DataGridView
                    PopulateDataGridView(feedbackResult);
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

        private StringBuilder ExtractTextFromRubric()
        {
            StringBuilder rubricString = new StringBuilder();

            if (assessment.CriteriaList == null || assessment.CriteriaList.Count == 0)
            {
                return rubricString; // Return empty if there's no criteria
            }

            // Append headers (Grade names)
            var headers = assessment.CriteriaList[0].RatingList.Select(r => r.Grade).ToArray();
            rubricString.AppendLine("Criteria | " + string.Join(" | ", headers));

            // Determine the separator length based on the headers
            int separatorLength = "Criteria".Length + headers.Sum(h => h.Length) + (headers.Length * 3);
            rubricString.AppendLine(new string('-', separatorLength));

            // Append each criteria and its ratings
            foreach (Criteria criteria in assessment.CriteriaList)
            {
                // Append the criteria description
                rubricString.Append(criteria.Description + " | ");

                // Append the ratings for this criteria
                var ratings = criteria.RatingList.Select(r => r.Description).ToArray();
                rubricString.AppendLine(string.Join(" | ", ratings));
            }

            return rubricString;
        }

        private async Task<FeedbackResult> GetFeedbackFromAI(string assessmentDocument, string teacherComments, string rubric, string note, double totalMarks)
        {
            var conversation = api.Chat.CreateConversation();

            // Append system message
            conversation.AppendMessage(ChatMessageRole.System, "You are an intelligent and empathetic educational assistant. Your goal is to help students improve by providing personalized feedback based on their assessment, teacher's comments, and the rubric provided. Your feedback should be constructive, encouraging, and specific, referencing direct quotes from the assessment document where applicable.");
            conversation.AppendMessage(ChatMessageRole.System, $"Here is the Subject Information: {assessment.CourseDescription} and Assessment Information: {assessment.Description}");

            // Append user messages
            conversation.AppendMessage(ChatMessageRole.User, $"Please review the following assessment document, teacher's comments, and rubric. Provide a grade as a mark out of {totalMarks}, personalized feedback to the student, and suggestions for improvement. For each criterion, specify the rating from the rubric the student received. Use quotes from the assessment document itself to make your feedback more impactful.");
            conversation.AppendMessage(ChatMessageRole.User, $"Additionally, please provide detailed next steps for the student on how to improve their work. Specify which sections or parts of the assessment need the most attention, what changes should be made, and any additional resources or strategies that could help enhance their submission.");
            conversation.AppendMessage(ChatMessageRole.User, $"Please use these notes from the student to provide guided feedback: {note}");
            conversation.AppendMessage(ChatMessageRole.User, $"Please divide your response into three sections titled 'Grade', 'Feedback', and 'Next Steps'.");
            conversation.AppendMessage(ChatMessageRole.User, $"Assessment Document: {assessmentDocument}, Teacher's Comments: {teacherComments}, Rubric: {rubric}");

            if(previousCb.CheckedItems != null)
            {
                conversation.AppendMessage(ChatMessageRole.User, "Listed below is past attempt of getting feedback under same assessment and course, use this as a guide to continously improve and provide helpful personalise dynamic feedback");
               
                foreach (string item in previousCb.CheckedItems)
                {
                    int attempt = Int32.Parse(item.Substring(0, item.IndexOf("Mark:")).Trim());
                    conversation.AppendMessage(ChatMessageRole.User, $"Previous History of past attempt Grade: {assessment.FeedbackList[attempt].Grade} Feedback: {assessment.FeedbackList[attempt].Feedback} Next Step {assessment.FeedbackList[attempt].NextStep}");
                }
            }

            // Get the response from the AI
            string response = await conversation.GetResponseFromChatbotAsync();

            Console.WriteLine("Raw API Response:");
            Console.WriteLine(response);

            // Parse the response into sections
            FeedbackResult feedbackResult = ParseResponseIntoSections(response, totalMarks);

            return feedbackResult;
        }

        private FeedbackResult ParseResponseIntoSections(string response, double totalMarks)
        {
            FeedbackResult feedbackResult = new FeedbackResult(assessment.FeedbackList.Count + 1, teacherRb.Text, assessment.StudentId, assessment.Id);

            try
            {
                // Extract and format the grade as "XX/XX"
                feedbackResult.Grade = ExtractGradeFromResponse(response, totalMarks);
                feedbackResult.Feedback = ExtractSection(response, "Feedback:").Trim();
                feedbackResult.NextStep = ExtractSection(response, "Next Steps:").Trim();

                // Parse criteria ratings
                foreach (var criteria in assessment.CriteriaList)
                {
                    // Assuming the AI responds with ratings in a format like "CriteriaName: Rating"
                    string criteriaRating = ExtractSection(response, criteria.Description + ":").Trim();
                    if (!string.IsNullOrEmpty(criteriaRating))
                    {
                        feedbackResult.CriteriaRatings[criteria.Description] = criteriaRating;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing response into sections: {ex.Message}");
            }

            return feedbackResult;
        }

        private string ExtractGradeFromResponse(string response, double totalMarks)
        {
            string gradeSection = ExtractSection(response, "Grade:");

            // Try to extract the numerical grade from the response
            if (int.TryParse(gradeSection, out int obtainedMarks))
            {
                // Return the grade in the format "XX/XX"
                return $"{obtainedMarks}/{totalMarks}";
            }

            // If the grade is not in a numerical format, return the original text
            return gradeSection.Trim();
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

        private void InitializeDataGridView()
        {
            criteriaRatingDgv.Columns.Clear();

            // Add a column for Criteria
            criteriaRatingDgv.Columns.Add("Criteria", "Criteria");

            // Add a column for Rating
            criteriaRatingDgv.Columns.Add("Rating", "Rating");
        }

        private void PopulateDataGridView(FeedbackResult feedbackResult)
        {
            InitializeDataGridView();

            // Clear existing rows
            criteriaRatingDgv.Rows.Clear();

            // Populate the DataGridView with criteria and their ratings
            foreach (var criteria in assessment.CriteriaList)
            {
                if (feedbackResult.CriteriaRatings.TryGetValue(criteria.Description, out string rating))
                {
                    // Add the criteria and rating to the DataGridView
                    criteriaRatingDgv.Rows.Add(criteria.Description, rating);
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.MainPannel(2);
        }
    }
}
