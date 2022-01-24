using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RatingDL: IRatingDL
    {
        GeneralDBContext generalDBContext;
        public RatingDL()
        {
            generalDBContext = new GeneralDBContext();
        }

       

      public async Task  AddToContext(Rating rating)
        {
            await generalDBContext.Ratings.AddAsync(rating);
           await generalDBContext.SaveChangesAsync();
        }
    }
}
