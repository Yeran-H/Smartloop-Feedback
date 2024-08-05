using System;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Smartloop_Feedback.Academic_Portfolio.AI
{
    public partial class AIForm : Form
    {
        //public Student student;
        //public MainForm mainForm;

        public AIForm()
        {
            InitializeComponent();
            //this.student = student;
            //this.mainForm = mainForm;
        }

        private void GenerateFeedbackButton_Click(object sender, EventArgs e)
        {
            string assessment = AssessmentTextBox.Text;
            string rubric = RubricTextBox.Text;
            string teacherComments = TeacherCommentsTextBox.Text;

            string feedback = GetFeedbackFromBertModel(assessment, rubric, teacherComments);
            FeedbackTextBox.Text = feedback;
        }

        private string GetFeedbackFromBertModel(string assessment, string rubric, string teacherComments)
        {
            var client = new RestClient("https://api-inference.huggingface.co/models/meta-llama/Meta-Llama-3.1-8B-Instruct");
            var request = new RestRequest(Method.Post.ToString());
            request.AddHeader("Authorization", "Bearer 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");
            request.AddHeader("Content-Type", "application/json");

            var input = new
            {
                inputs = new
                {
                    text = $"{assessment}\n{rubric}\n{teacherComments}"
                }
            };

            request.AddJsonBody(input);
            var response = client.Execute(request);

            if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
            {
                try
                {
                    var jsonResponse = JObject.Parse(response.Content);
                    if (jsonResponse["generated_text"] != null)
                    {
                        return jsonResponse["generated_text"].ToString();
                    }
                    else
                    {
                        return "Error: Unable to generate feedback. The API did not return the expected result.";
                    }
                }
                catch (Exception ex)
                {
                    return $"Error: Failed to parse the response. {ex.Message}";
                }
            }
            else
            {
                return $"Error: API request failed with status {response.StatusCode} and message {response.ErrorMessage}";
            }
        }
    }
}
