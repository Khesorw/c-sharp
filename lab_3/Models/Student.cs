
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Student
    {




        
        [MinLength(2),DataType(DataType.Text)]
        
        public string FristName { get; set; }

        public string LastName
        {
            get;set;
        }

        public int StudentId
        {
            get; set;
        }

        public int sdNum { set;get; }

        public string EmailAddress
        {
            get;set;
        }

        public string Password
        {
            get;set;
        }

        public string Description_Of_Student
        {
            get; set;
        }



        public Student() { }
        public Student(string fristName, string lastName, int studentId, string emailAddress, string password, string description_Of_Student)
        {
            FristName = fristName;
            LastName = lastName;
            StudentId = studentId;
            EmailAddress = emailAddress;
            Password = password;
            Description_Of_Student = description_Of_Student;
        }


    }//student class
}
