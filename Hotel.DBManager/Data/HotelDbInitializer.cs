using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel.DBManager.Data
{
    public class HotelDbInitializer: CreateDatabaseIfNotExists<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
          
            base.Seed(context);
        }
    }
}
