using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApplication1.Models
{
    public class Post
    {

        public long Id{get;set;}

        private string _key;

        public string Key{
          get{
            if(_key == null){
              _key = Regex.Replace(title.ToLower(),"[^a-z0-9]","-");
            }
            return _key;
          }
          set{
            _key = value;
          }
        }

        [Display(Name ="First Name")]
        [Required]
       
       public string Name { get;set; }

        [Required,Display(Name = "Last Name")]
       
      public string lname { set; get; }

        [Required]
        [DataType(DataType.MultilineText)]
       // [StringLength(100, MinimumLength = 3, ErrorMessage = "Invalid thing ....")]
        public   string title { set; get; }


        public Post() { }

       


    }
}
