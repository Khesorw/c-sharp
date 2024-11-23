using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Student
    {

        [Required]
        [Key]
        [Editable(false)]
        public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(3)]
        [DisplayName("First Name")]
        [DataType(DataType.Text)]

        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(3)]
        [DisplayName("Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }


        [Required]
        [StringLength(50)]
        [MinLength(3)]
        [DisplayName("Program")]
        public string Program { get; set; } 

    }
}
