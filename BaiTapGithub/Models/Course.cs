using System.Text.Json.Serialization;

namespace BaiTapGithub.Models
{
    public class Course
    {

        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        [JsonIgnore]

        public ICollection<Student>? Students { get; set; }
    }
}
