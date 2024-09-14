using System;
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
using System.IO;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
using Smartloop_Feedback.Objects.Updated;

namespace Smartloop_Feedback.Academic_Portfolio.AI
{
    public partial class AIForm : Form
    {
        private readonly string apiKey = ConfigurationManager.AppSettings["OpenAi_Apikey"];
        private OpenAIAPI api;
        public StudentAssessment assessment;
        public MainForm mainForm;

        public AIForm(StudentAssessment assessment, MainForm mainForm)
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
                previousAttemptCb.Items.Add(feedbackResult.Attempt);
            }

            assessment.GeneratePastAssessment();

            foreach(Tuple<String, string> past in assessment.PastAssessment)
            {
                previousAssessmentCb.Items.Add(past.Item1);
            }

            if (mainForm.position[4] != null)
            {
                teacherRb.Text = assessment.FeedbackList[(int)mainForm.position[4]].TeacherFeedback;
                noteRb.Text = assessment.FeedbackList[(int)mainForm.position[4]].Notes;
                fileTb.Text = assessment.FeedbackList[(int)mainForm.position[4]].FileName;
                feedbackRb.Text = assessment.FeedbackList[(int)mainForm.position[4]].Feedback;
                feedbackBtn.Visible = false;
                loadAssessmentBtn.Text = "Download Assessment";

                foreach(int attempt in assessment.FeedbackList[(int)mainForm.position[4]].PreviousAttemptId)
                {
                    for(int i = 0; i < previousAttemptCb.Items.Count; i++)
                    {
                        if ((int)previousAttemptCb.Items[i] == attempt)
                        {
                            previousAttemptCb.SetItemChecked(i, true);
                            break;
                        }
                    }
                }

                foreach (string pastAssessment in assessment.FeedbackList[(int)mainForm.position[4]].PreviousAssessmentId)
                {
                    for (int i = 0; i < previousAssessmentCb.Items.Count; i++)
                    {
                        if ((string)previousAssessmentCb.Items[i] == pastAssessment)
                        {
                            previousAssessmentCb.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
        }

        private void loadAssessmentBtn_Click(object sender, EventArgs e)
        {
            if(loadAssessmentBtn.Text == "Load Assessment") 
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileTb.Text = openFileDialog.FileName;
                }
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = assessment.FeedbackList[(int)mainForm.position[4]].FileName; 

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, assessment.FeedbackList[(int)mainForm.position[4]].FileData);
                    MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
                string feedback = await GetFeedbackFromAI(assessmentDocument, teacherComments, rubric, note, totalMarks);

                if (feedback != null)
                {
                    feedbackRb.Text = feedback;
                    fileTb.Text = System.IO.Path.GetFileName(fileTb.Text);

                    int[] previousAttemptList = new int[previousAttemptCb.CheckedItems.Count];
                    string[] previousAssessmentList = new string[previousAssessmentCb.CheckedItems.Count];

                    if (previousAttemptCb.CheckedItems != null)
                    {
                        foreach (int attempt in previousAttemptCb.CheckedItems)
                        {
                            previousAttemptList = new int[attempt];
                        }
                    }

                    if (previousAssessmentCb.CheckedItems != null)
                    {
                        int index = 0;
                        foreach (string item in previousAssessmentCb.CheckedItems)
                        {
                            previousAssessmentList[index] = item;
                            index++;
                        }
                    }

                    FeedbackResult feedbackResult = new FeedbackResult(assessment.FeedbackList.Count + 1, teacherRb.Text, System.IO.Path.GetFileName(fileTb.Text), Encoding.UTF8.GetBytes(assessmentDocument), noteRb.Text, feedback, previousAttemptList, previousAssessmentList, assessment.UserId, assessment.Id);
                    assessment.FeedbackList.Add(feedbackResult.Id, feedbackResult);
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

        private async Task<string> GetFeedbackFromAI(string assessmentDocument, string teacherComments, string rubric, string note, double totalMarks)
        {
            var conversation = api.Chat.CreateConversation();

            // Append system message
            conversation.AppendMessage(ChatMessageRole.System, "You are an intelligent and empathetic educational assistant. Your goal is to help students improve by providing personalized feedback based on their assessment, teacher's comments, and the rubric provided. Your feedback should be constructive, encouraging, and specific, referencing direct quotes from the assessment document where applicable.");
            conversation.AppendMessage(ChatMessageRole.System, $"Here is the Subject Information: {assessment.CourseDescription} and Assessment Information: {assessment.Description}");

            // Append user messages
            conversation.AppendMessage(ChatMessageRole.User, $"Please review the following assessment document, teacher's comments, and rubric. Provide a grade as a mark out of {totalMarks}, personalized feedback to the student, and suggestions for improvement. For each criterion, specify the rating from the rubric the student received. Use quotes from the assessment document itself to make your feedback more impactful.");
            conversation.AppendMessage(ChatMessageRole.User, $"Additionally, please provide detailed next steps for the student on how to improve their work. Specify which sections or parts of the assessment need the most attention, what changes should be made, and any additional resources or strategies that could help enhance their submission.");
            conversation.AppendMessage(ChatMessageRole.User, $"Please use these notes from the student to provide guided feedback: {note}");
            conversation.AppendMessage(ChatMessageRole.User, $"Please divide your response into four sections titled 'Grade', 'Feedback', 'Next Steps' and 'Criterion', specify the rating based on the rating the student received.");
            conversation.AppendMessage(ChatMessageRole.User, $"Assessment Document: {assessmentDocument}, Teacher's Comments: {teacherComments}, Rubric: {rubric}");

            if(previousAttemptCb.CheckedItems.Count != 0)
            {
                conversation.AppendMessage(ChatMessageRole.User, "Listed below is past attempt of getting feedback under same assessment and course, use this as a guide to continously improve and provide helpful personalise dynamic feedback");
               
                foreach (int item in previousAttemptCb.CheckedItems)
                {
                    conversation.AppendMessage(ChatMessageRole.User, $"Previous History of past Feedback: {assessment.FeedbackList[item].Feedback}");
                }
            }

            if (previousAssessmentCb.CheckedItems.Count != 0)
            {
                conversation.AppendMessage(ChatMessageRole.User, "Listed below is past assessment from same course, use this as a guide to continously improve and provide helpful personalise dynamic feedback");

                foreach (int item in previousAttemptCb.CheckedItems)
                {
                    conversation.AppendMessage(ChatMessageRole.User, $"Previous History of past general feedback: {assessment.PastAssessment[item - 1].Item2}");
                }
            }

            // Get the response from the AI
            string response = await conversation.GetResponseFromChatbotAsync();

            Console.WriteLine("Raw API Response:");
            Console.WriteLine(response);

            return response;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            mainForm.position[4] = null;
            mainForm.MainPannel(2);
        }
    }
}
