using System;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Quote
    {
        [Required]
        [MinLength(2)]
        [MaxLength(45)]
        public string Name { get; set;}

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string QuoteData { get; set; }
    }
}