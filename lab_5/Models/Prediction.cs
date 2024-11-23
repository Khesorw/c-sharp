using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lab5.Models
{

    public enum Question
    {
        Earth,Computer
    }
    public class Prediction
    {

        
        public int PredectionId { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        [MinLength(4),MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Url")]
        [DataType(DataType.Upload)]
        
        public string Url { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public Question Question { get; set; }

        [Display(Name = "Experience Level")]
        public string QuestionType
        {
            get
            {
                return Question == Question.Earth ? "Earth" : "Computers";
            }
        }

    }
}
