using Smartloop_Feedback.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Smartloop_Feedback.Results
{
    public partial class ResultForm : Form
    {
        public Student student;
        public List<CourseResult> courseResultList;
        public List<double> wamYearList;
        public List<double> wamSemesterList;
        public List<double> gpaYearList;
        public List<double> gpaSemesterList;

        public ResultForm(Student student)
        {
            InitializeComponent();
            this.student = student;
            this.courseResultList = new List<CourseResult>();
            this.wamYearList = new List<double>();
            this.wamSemesterList = new List<double>();
            this.gpaYearList = new List<double>();
            this.gpaSemesterList = new List<double>();
        }


        private void ResultForm_Load(object sender, EventArgs e)
        {
            PopulateDgv();
            filterCb.Text = "Year";
            PopulateCharts();
            CalculateWAMGPA();
        }

        private void PopulateDgv()
        {
            foreach (Year year in student.yearList.Values)
            {
                double wamYear = 0.0;
                double gpaYear = 0.0;
                int totalCreditPointsYear = 0;

                foreach (Semester semester in year.semesterList.Values)
                {
                    double wamSemester = 0.0;
                    double gpaSemester = 0.0;
                    int totalCreditPointsSemester = 0;

                    foreach (Course course in semester.courseList.Values)
                    {
                        CourseResult courseResult = new CourseResult
                        {
                            Year = year.name,
                            Semester = semester.name,
                            Course = course.title,
                            Score = course.CalculateCurrentMark(),
                            CreditPoint = course.creditPoint
                        };
                        courseResult.CalculateGrade();

                        courseResultList.Add(courseResult);

                        // Update semester aggregates
                        wamSemester += courseResult.Score * courseResult.CreditPoint;
                        gpaSemester += courseResult.GetGradePoint() * courseResult.CreditPoint;
                        totalCreditPointsSemester += courseResult.CreditPoint;
                    }

                    // Calculate WAM and GPA for the semester
                    if (totalCreditPointsSemester > 0)
                    {
                        wamSemester /= totalCreditPointsSemester;
                        gpaSemester /= totalCreditPointsSemester;
                    }

                    // Update year aggregates
                    wamYear += wamSemester * totalCreditPointsSemester;
                    gpaYear += gpaSemester * totalCreditPointsSemester;
                    totalCreditPointsYear += totalCreditPointsSemester;

                    wamSemesterList.Add(wamSemester);
                    gpaSemesterList.Add(gpaSemester);
                }

                // Calculate WAM and GPA for the year
                if (totalCreditPointsYear > 0)
                {
                    wamYear /= totalCreditPointsYear;
                    gpaYear /= totalCreditPointsYear;

                    wamYearList.Add(wamYear);
                    gpaYearList.Add(gpaYear);
                }
            }

            resultDgv.DataSource = courseResultList;
        }

        private void PopulateCharts()
        {
            // Clear existing data points
            wamChart.Series["WAM"].Points.Clear();
            gpaChart.Series["GPA"].Points.Clear();

            List<double> wamList;
            List<double> gpaList;

            if (filterCb.SelectedItem.ToString() == "Year")
            {
                wamList = wamYearList;
                gpaList = gpaYearList;
            }
            else 
            {
                wamList = wamSemesterList;
                gpaList = gpaSemesterList;
            }

            // Populate WAM chart
            for (int i = 0; i < wamList.Count; i++)
            {
                wamChart.Series["WAM"].Points.AddXY(i + 1, wamList[i]);
            }

            // Populate GPA chart
            for (int i = 0; i < gpaList.Count; i++)
            {
                gpaChart.Series["GPA"].Points.AddXY(i + 1, gpaList[i]);
            }
        }

        private void CalculateWAMGPA()
        {
            double totalWAM = 0.0;
            double totalGPA = 0.0;
            int totalCreditPoints = 0;

            // Ensure that totalCreditPoint is the sum of all credit points
            foreach (Year year in student.yearList.Values)
            {
                foreach (Semester semester in year.semesterList.Values)
                {
                    foreach (Course course in semester.courseList.Values)
                    {
                        totalCreditPoints += course.creditPoint;
                    }
                }
            }

            // Calculate the total WAM
            for (int i = 0; i < wamYearList.Count; i++)
            {
                totalWAM += wamYearList[i] * student.yearList.Values.ElementAt(i).semesterList.Values.Sum(s => s.courseList.Values.Sum(c => c.creditPoint));
            }

            // Calculate the total GPA
            for (int i = 0; i < gpaYearList.Count; i++)
            {
                totalGPA += gpaYearList[i] * student.yearList.Values.ElementAt(i).semesterList.Values.Sum(s => s.courseList.Values.Sum(c => c.creditPoint));
            }

            if (totalCreditPoints > 0)
            {
                totalWAM /= totalCreditPoints;
                totalGPA /= totalCreditPoints;
            }

            // Print the total WAM and GPA
            wamTb.Text= totalWAM.ToString();
            gpaTb.Text= totalGPA.ToString();
        }


        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            (resultDgv.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("Course LIKE '%{0}%' OR Grade LIKE '%{0}%' OR Score LIKE '%{0}%'", searchTextBox.Text);
        }

        private void resultDgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = resultDgv.Columns[e.ColumnIndex];
            if (resultDgv.SortOrder == SortOrder.Ascending)
            {
                resultDgv.Sort(column, ListSortDirection.Descending);
            }
            else
            {
                resultDgv.Sort(column, ListSortDirection.Ascending);
            }
        }

        private void filterCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCharts();
        }
    }
}
