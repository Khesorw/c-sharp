using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPractice.Data.Models;

namespace RazorPractice.Pages
{
    public class MoviesModel : PageModel
    {
        public List<RazorPractice.Data.Models.Movie> Movies { get; set; }
        public void OnGet()
        {
            Movies = new List<RazorPractice.Data.Models.Movie>() {

               new Movie {Id = 1,Title = "Titanic",Description = "Romance",Rate = 8},
               new Movie {Id = 2,Title = "Avatar", Rate = 8,Description="Si-Fi"},
                new Movie {Id = 3,Title = "Kong", Rate = 8,Description="Sci-Fi"},
                new Movie {Id = 4,Title = "Star wars", Rate = 3,Description="Si-Fi"},

            };
        }
    }
}
