using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hotel.Domain.Entities
{
    public class Room
    {
        [HiddenInput(DisplayValue = false)]
        public int RoomId { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Required(ErrorMessage ="Please, enter the price/room")]
        [Range(10, 1000)]
        public float Price { get; set; }

        [Display(Name ="Count Of People")]
        [Required(ErrorMessage = "Please, enter the max count of people")]
        [Range(1, 6)]
        public int CountOfPeople { get; set; }

        [Required(ErrorMessage ="Plese, enter the room class")]
        public string RoomClass { get; set; }

        [Required(ErrorMessage = "Plese, enter the room state")]
        public string RoomState { get; set; }


        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

    }
}
