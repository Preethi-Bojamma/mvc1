using mvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc1.ViewModel
{
    public class MovieCustomerViewModel
    {
        public customer cm { get; set; }
        public List<MovieB> mb{ get; set; }
    }
}