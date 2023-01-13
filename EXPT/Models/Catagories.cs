using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EXPT.Models
{
    public class Catagories
    {
        [Key]
        public int ID { get; set; }
        public string Catagory { get; set; }
        public string Limit { get; set; }
    }
}