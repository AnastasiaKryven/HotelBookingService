using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hotel.Domain.Entities
{
    public class Review
    {
        public Review()
        {
            Date = DateTime.Now;
        }

        [HiddenInput(DisplayValue = false)]
        public int ReviewId { get; set; }

        public Client ClientName { get; set; }

        [Display(Name ="Your Feedback")]
        [DataType(DataType.MultilineText)]
        public string TextOfReview { get; set; }

        public DateTime Date { get; set; }


    }
}
