using Hotel.DBManager.Data;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DBManager.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        HotelContext db = new HotelContext();

        public ReviewRepository(HotelContext db)
        {
            this.db = db;
        }

        public IEnumerable<Review> Reviews => db.Reviews;

        public void Create(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
        }

    }
}
