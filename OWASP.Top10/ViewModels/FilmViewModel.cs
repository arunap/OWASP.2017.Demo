using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OWASP.Top10.ViewModels
{
    public class FilmViewModel
    {
        public string FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public decimal Rental { get; set; }
        public string CategoryName { get; internal set; }
    }
}