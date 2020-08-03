using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StudentApp.Core.Model
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
