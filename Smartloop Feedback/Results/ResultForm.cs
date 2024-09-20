using Smartloop_Feedback.Objects;
using Smartloop_Feedback.Objects.Updated.User_Object;
using Smartloop_Feedback.Objects.Updated.User_Object.Student;
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
        public User user;
        public List<StudentCourseResult> courseResultList;
        public List<double> wamYearList;
        public List<double> wamSemesterList;
        public List<double> gpaYearList;
        public List<double> gpaSemesterList;

        public ResultForm(User user)
        {
            InitializeComponent();
            this.user = user;
            this.courseResultList = new List<StudentCourseResult>();
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
            foreach (Objects.Updated.User_Object.YearAssociation year in user.YearList.Values)
            {
                double wamYear = 0.0;
                double gpaYear = 0.0;
                int totalCreditPointsYear = 0;

                foreach (SemesterAssociation semester in year.SemesterList.Values)
                {
                    double wamSemester = 0.0;
                    double gpaSemester = 0.0;
                    int totalCreditPointsSemester = 0;

                    foreach (CourseAssociation course in semester.CourseList.Values)
                    {
                        if(course is StudentCourse studentCourse)
                        {
                            StudentCourseResult courseResult = new StudentCourseResult
                            {
                                Year = year.Name,
                                Semester = semester.Name,
                                Course = studentCourse.Name,
                                Score = studentCourse.CalculateCurrentMark(),
                                CreditPoint = studentCourse.CreditPoint
                            };
                            courseResult.CalculateGrade();

                            courseResultList.Add(courseResult);

                            // Update semester aggregates
                            wamSemester += courseResult.Score * courseResult.CreditPoint;
                            gpaSemester += courseResult.GetGradePoint() * courseResult.CreditPoint;
                            totalCreditPointsSemester += courseResult.CreditPoint;
                        }
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
            DataGridColor(resultDgv);
        }

        // Apply custom color formatting to a DataGridView
        private void DataGridColor(System.Windows.Forms.DataGridView grid)
        {
            // Set DataGridView properties
            grid.BackgroundColor = Color.FromArgb(16, 34, 61);
            grid.GridColor = Color.FromArgb(254, 0, 57);
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
            grid.DefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set column header style
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set row header style
            grid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
            grid.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
            grid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.RowHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set cell border style
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);

            // Set button cell style specifically
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.CellTemplate is StyledButtonCell)
                {
                    col.DefaultCellStyle.BackColor = Color.FromArgb(16, 34, 61);
                    col.DefaultCellStyle.ForeColor = Color.FromArgb(193, 193, 193);
                    col.DefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 34, 61);
                    col.DefaultCellStyle.SelectionForeColor = Color.FromArgb(193, 193, 193);
                }
            }
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
            foreach (Objects.Updated.User_Object.YearAssociation year in user.YearList.Values)
            {
                foreach (SemesterAssociation semester in year.SemesterList.Values)
                {
                    foreach (CourseAssociation course in semester.CourseList.Values)
                    {
                        totalCreditPoints += course.CreditPoint;
                    }
                }
            }

            // Calculate the total WAM
            for (int i = 0; i < wamYearList.Count; i++)
            {
                totalWAM += wamYearList[i] * user.YearList.Values.ElementAt(i).SemesterList.Values.Sum(s => s.CourseList.Values.Sum(c => c.CreditPoint));
            }

            // Calculate the total GPA
            for (int i = 0; i < gpaYearList.Count; i++)
            {
                totalGPA += gpaYearList[i] * user.YearList.Values.ElementAt(i).SemesterList.Values.Sum(s => s.CourseList.Values.Sum(c => c.CreditPoint));
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
