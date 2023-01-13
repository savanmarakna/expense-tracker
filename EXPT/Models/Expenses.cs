using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EXPT.Models
{
    public class Expenses
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string Catid { get; set; }
        public string Date { get; set; }
    }
}