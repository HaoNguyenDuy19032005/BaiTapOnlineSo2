using System.Text.Json.Serialization;

namespace BaiTapGithub.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public int? CourseID { get; set; }
        public Course Course { get; set; }
    }
}
