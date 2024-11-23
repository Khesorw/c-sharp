using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Lab4.Models
{
    public class Client
    {

        public int Id { get; set; }




        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Text),StringLength(50,ErrorMessage ="Invalid Last Name 😡😡")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Text), StringLength(50, ErrorMessage = "Invalid Name 😡😡")]
        [Display(Name = "Name")]
        public string FirstName { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name = "Birth Date")]
       public DateTime BirthDate { get; set; }


        public List<Subscription> Subscriptions { get; set; }
        public string FullName { get {


                return FirstName + " " + LastName;


            }  }
        





    }
}
