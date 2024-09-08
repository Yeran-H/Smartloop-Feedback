using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Org.BouncyCastle.Crypto.Paddings;
using Smartloop_Feedback.Objects;


namespace Smartloop_Feedback.Objects
{
    public class Assessment
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime Date {  get; set; }
        public double Weight { get; set; }
        public double Mark {  get; set; }
        public string CanvasLink { get; set; }
        public List<Criteria> CriteriaList { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public int CourseId { get; set; }

        public Assessment(int id, string name, string description, string type, DateTime date, double weight, double mark, string canvasLink, string fileName, byte[] fileData, int courseId)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            Date = date;
            Weight = weight;
            Mark = mark;
            CanvasLink = canvasLink;
            FileName = fileName;
            FileData = fileData;
            CourseId = courseId;
            CriteriaList = new List<Criteria>();
        }

        public Assessment(string name, string description, string type, DateTime date, double weight, double mark, string canvasLink, string fileName, byte[] fileData, int courseId)
        {
            Name = name;
            Description = description;
            Type = type;
            Date = date;
            Weight = weight;
            Mark = mark;
            CanvasLink = canvasLink;
            FileName = fileName;
            FileData = fileData;
            CourseId = courseId;
        }
    }
}
