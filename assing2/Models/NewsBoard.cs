using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.Models
{
    public class NewsBoard
    {

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Registration Number")]
        public string Id { get; set; }


        [Required,StringLength(50),MinLength(3)]
        public string Title { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Fee { get; set; }


        public List<Subscription> Subscriptions { get; set; }

        public List<News> News { get; set; }




    }
}
