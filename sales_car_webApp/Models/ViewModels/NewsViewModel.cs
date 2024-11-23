using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models.ViewModels
{
    public class NewsViewModel
    {
        public NewsBoard NewsBoard { get; set; }
        public IEnumerable<News> News { get; set; }

    }
}