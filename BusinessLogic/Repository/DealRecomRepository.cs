using BusinessLogic.Interface;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class DealRecomRepository : IDealRecom
    {
        private readonly AwfirContext db;
        public DealRecomRepository(AwfirContext context)
        {
            db = context;
        }
        public string InsertUpdateDealRecom(DealRecom dealRecom)
        {
            try
            {
               
                if(dealRecom != null)
                {   
                    
                    var data = db.DealRecoms.Where(x => x.DealID == dealRecom.DealID).FirstOrDefault();
                    {
                        var avg = db.DealReviews.Where(x => x.DealID == dealRecom.DealID).Select(x => x.Rating).ToList().Average();

                        if (data != null)
                        {
                            data.AverageRating = Convert.ToDecimal(avg);
                            data.TotalReviews = data.TotalReviews + 1;
                            data.TotalLikes = data.TotalLikes + 1;
                            db.SaveChanges();
                            return ("Ok");
                        }
                        else
                        {
                            DealRecom DR = new DealRecom();
                            DR.DealID = dealRecom.DealID;
                            DR.AverageRating = Convert.ToDecimal(avg);
                            DR.TotalReviews = 1;
                            DR.TotalLikes = 1;
                            db.DealRecoms.Add(DR);
                            db.SaveChanges();
                            return ("Ok");
                        }
                    }
                }
                else
                {
                    return (null);
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
