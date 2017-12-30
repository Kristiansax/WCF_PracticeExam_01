using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfWebApplication.Models
{
    public class Bid
    {
        public int ItemNumber { get; set; }
        public int Price { get; set; }
        public string CustomName { get; set; }
        public string CustomPhone { get; set; }
    }
}