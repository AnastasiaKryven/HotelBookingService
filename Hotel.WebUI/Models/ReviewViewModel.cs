using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.WebUI.Models
{
    public class ReviewViewModel
    {
        public IEnumerable<Review> Reviews;
    }
}