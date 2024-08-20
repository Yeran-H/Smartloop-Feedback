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
using System.Drawing;
using OpenAI_API.Completions;
using System.Drawing.Imaging;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Smartloop_Feedback.Academic_Portfolio.AI
{
    public partial class AIDiagramForm : Form
    {
        private readonly string openAiApiKey = ConfigurationManager.AppSettings["OpenAi_Apikey"];
        private readonly string rapidApiKey = "99398a7f83msh1ec6c0582f0263ep122698jsn4286c0e64707"; 
        private OpenAIAPI api;
        public Assessment assessment;
        public MainForm mainForm;

        public AIDiagramForm()
        {
            InitializeComponent();
            api = new OpenAIAPI(openAiApiKey);
            //this.mainForm = mainForm;
            //this.assessment = assessment;
        }

        private void AIDiagramForm_Load(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            //mainForm.position[4] = null;
            //mainForm.MainPannel(2);
        }

        private void loadAssessmentBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select a Diagram",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            // Show the dialog and get the result
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the image into the PictureBox
                    string selectedFileName = openFileDialog.FileName;
                    diagramPb.Image = Image.FromFile(selectedFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void feedbackBtn_Click(object sender, EventArgs e)
        {
            byte[] diagram = ConvertImageToByteArray(diagramPb);
            string diagramType = diagramTb.Text;
            string teacherComments = teacherRb.Text;
            string note = noteRb.Text;

            try
            {
                // Step 1: Extract text from the image using the OCR API
                string extractedText = await ExtractTextFromImageAsync(diagram, rapidApiKey);

                // Step 2: Analyze the extracted text using the OpenAI API
                string feedback = await GetFeedbackFromAI(extractedText, diagramType, note, teacherComments);

                if (feedback != null)
                {
                    feedbackRb.Text = feedback;

                    int[] previousAttemptList = new int[previousAttemptCb.CheckedItems.Count];

                    if (previousAttemptCb.CheckedItems != null)
                    {
                        foreach (int attempt in previousAttemptCb.CheckedItems)
                        {
                            previousAttemptList = new int[attempt];
                        }
                    }

                    //FeedbackResult feedbackResult = new FeedbackResult(assessment.FeedbackList.Count + 1, teacherRb.Text, System.IO.Path.GetFileName(fileTb.Text), Encoding.UTF8.GetBytes(assessmentDocument), noteRb.Text, feedback, previousAttemptList, previousAssessmentList, assessment.StudentId, assessment.Id);
                    //assessment.FeedbackList.Add(feedbackResult.Id, feedbackResult);
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

        public byte[] ConvertImageToByteArray(PictureBox pictureBox)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Save the image to the MemoryStream in the desired format (e.g., PNG)
                pictureBox.Image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public async Task<string> ExtractTextFromImageAsync(byte[] imageData, string apiKey)
        {
            using (var client = new HttpClient())
            {
                // Correct API endpoint
                string apiUrl = "https://ocr43.p.rapidapi.com/v1/results";

                // Set up the request headers
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "ocr43.p.rapidapi.com");

                // Set up the request content
                var form = new MultipartFormDataContent();

                // Add the image file (byte array) to the form data with the correct field name "image"
                var imageContent = new ByteArrayContent(imageData);
                imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                form.Add(imageContent, "image", "image.png");

                try
                {
                    // Make the request to the OCR API
                    var response = await client.PostAsync(apiUrl, form);

                    if (!response.IsSuccessStatusCode)
                    {
                        // Log or display detailed error information
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"API request failed with status code {response.StatusCode}: {errorContent}");
                    }

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseBody);

                    // Extract text from the response (adjust based on actual JSON structure)
                    string extractedText = json["result"]?["ocr"]?["text"]?.ToString();

                    return extractedText ?? "No text found.";
                }
                catch (Exception ex)
                {
                    // Log the error details
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }


        public async Task<string> GetFeedbackFromAI(string extractedText, string diagramType, string notes, string teacherFeedback)
        {
            // Create the prompt for the AI
            var prompt = $"You are an expert in reviewing {diagramType} diagrams. Here is the text extracted from an image: {extractedText}. Please provide detailed feedback on the structure, correctness, and areas of improvement. Additionally, suggest an improved version of the diagram in a C# class layout or pseudocode. Here are additional notes and teacher feedback for your reference: {notes} and {teacherFeedback}.";

            // Call the OpenAI API with the constructed prompt
            var response = await api.Completions.CreateCompletionAsync(new CompletionRequest
            {
                Prompt = prompt,
                MaxTokens = 800, // Increase if needed for longer responses
                Temperature = 0.7 // Adjust as necessary for more creative or conservative suggestions
            });

            // Return the AI's feedback and suggested improvement
            return response.Completions[0].Text;
        }
    }
}
