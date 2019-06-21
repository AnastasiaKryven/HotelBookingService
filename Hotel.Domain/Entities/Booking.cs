using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hotel.Domain.Entities
{
    public class Booking
    {
        [HiddenInput (DisplayValue = false)]
        public int BookingId { get; set; }

        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Required]
        public Room Room { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEntry { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateExit { get; set; }
    }
}
