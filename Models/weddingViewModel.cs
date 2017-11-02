using System.ComponentModel.DataAnnotations;
using System;

namespace weddingPlanner.Models
{
    public class WeddingViewModel
    {
        [Required]
        public string newlywedOne {get; set;}
        [Required]
        public string newlywedTwo {get; set;}
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode=true)]
        [FutureDate(ErrorMessage="Error! Date is bad!")]
        public DateTime date {get; set;}
        [Required]
        public string address {get; set;}
    }

}