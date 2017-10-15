using System;
using System.ComponentModel.DataAnnotations;

namespace AngularTest2.Models
{
    public class Quote
    {
        [Key] public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}