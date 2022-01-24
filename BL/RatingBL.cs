using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;

namespace BL
{

  public class RatingBL:IRatingBL
    {
        IRatingDL ratingDL;
        public RatingBL(IRatingDL ratingDL)
        {
            this.ratingDL = ratingDL;
        }

        public async  Task AddToContext(Rating rating)
        {
           await  ratingDL.AddToContext(rating);
        }
    }
}
