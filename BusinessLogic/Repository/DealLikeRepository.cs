using BusinessLogic.Interface;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class DealLikeRepository : IDealLike
    {
        private readonly AwfirContext db;

        public DealLikeRepository(AwfirContext context)
        {
            db = context;
        }

        public string InsertDealLike(DealLike dealLike)
        {
            try
            {
                if(dealLike != null)
                {
                    DealLike DL = new DealLike();
                    DL.DealID = dealLike.DealID;
                    DL.UserID = dealLike.UserID;
                    DL.LikedDate = DateTime.Now;
                    db.DealLikes.Add(DL);
                    db.SaveChanges();
                    return("Ok");
                }
                else
                {
                    return(null);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }



    }
}
