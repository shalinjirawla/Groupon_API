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
                    var record = db.DealLikes.Where(x => x.DealID == dealLike.DealID && x.UserID == dealLike.UserID).FirstOrDefault();
                    if(record != null)
                    {
                        if(dealLike.LikeStatus == true)
                        {
                            record.LikeStatus = dealLike.LikeStatus;
                            db.SaveChanges();

                            var dealrecoms = db.DealRecoms.FirstOrDefault(x => x.DealID == dealLike.DealID);
                            dealrecoms.TotalLikes = dealrecoms.TotalLikes + 1;
                            db.SaveChanges();
                            return ("Ok");
                        }
                        else
                        {
                            record.LikeStatus = dealLike.LikeStatus;
                            var dealrecoms = db.DealRecoms.FirstOrDefault(x => x.DealID == dealLike.DealID);
                            dealrecoms.TotalLikes = dealrecoms.TotalLikes - 1;
                            db.SaveChanges();
                            return ("Ok");
                        }
                         
                    }
                    else
                    {
                        DealLike DL = new DealLike();
                        DL.DealID = dealLike.DealID;
                        DL.UserID = dealLike.UserID;
                        DL.LikedDate = DateTime.Now;
                        DL.LikeStatus = dealLike.LikeStatus;
                        db.DealLikes.Add(DL);
                        db.SaveChanges();
                        return ("Ok");
                    }
                    
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

        public DealLike CheckLike(Guid DealID, Guid UserID)
        {
            try
            {
                if(DealID != null && UserID != null)
                {
                    DealLike record = db.DealLikes.Where(x => x.DealID == DealID && x.UserID == UserID).FirstOrDefault();
                    if (record != null)
                    {
                        return (record);
                    }
                    else
                    {
                        return (null);
                    }
                }
                else
                {
                    return (null);
                }
               
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        

    }
}
