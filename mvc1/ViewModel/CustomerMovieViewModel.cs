using mvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc1.ViewModel
{
    public class CustomerMovieViewModel
    {
        public MovieB Movie{ get; set; }
        public List<customer> Customers{ get; set; }
    }
}