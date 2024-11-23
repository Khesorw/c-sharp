



using System.ComponentModel.DataAnnotations;

namespace Scaf.Models
{
    public class Student
    {


        [Key]
        public int StudentId { get; set; } 


        public string? name { get; set; }

        public string? lname { get; set; }

        public int age { get; set; }

        public string? grade { get; set; }

    }
}
