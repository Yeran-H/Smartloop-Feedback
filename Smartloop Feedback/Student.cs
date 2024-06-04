using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartloop_Feedback
{
    public class Student
    {
        public string name { get; set; }
        public string email { get; set; }
        public int studentId { get; set; }
        public string password { get; set; }
        public string degree { get; set; }
        public byte[] profileImage { get; set; }

        public Student(string name, string email, int studentId, string password, string degree, byte[] profileImage)
        {
            this.name = name;
            this.email = email;
            this.studentId = studentId;
            this.password = password;
            this.degree = degree;
            this.profileImage = profileImage;
        }

        public Student() { }

        public bool ValidatePassword()
        {
            return password.Length >= 8;
        }

        public bool ValidateStudentId()
        {
            string studentIdStr = studentId.ToString();
            return studentIdStr.Length == 8;
        }

        public bool ValidateEmail()
        {
            return Regex.IsMatch(email, @"@(student\.uts\.edu\.au|gmail\.com)$");
        }
    }
}
