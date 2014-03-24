using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CYSBasicSystemUI.Models
{
    public class Product
    {
        public string Itemid { set; get; }
        public string Productid { set; get; } 
        public string Productname { set; get; } 
        public double Unitcost { set; get; } 
        public string Status { set; get; } 
        public double Listprice { set; get; } 
        public string Attr1 { set; get; } 
    }
}