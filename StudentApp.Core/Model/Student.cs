using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Core.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public List<Subject> Subjects { get; set; }
    }
}
