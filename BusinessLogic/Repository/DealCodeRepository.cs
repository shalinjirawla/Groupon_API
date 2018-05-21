using BusinessLogic.Interface;
using BusinessLogic.Models;
using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BusinessLogic.Repository
{
    public class DealCodeRepository : IDealCode
    {
        private readonly AwfirContext db;
        public DealCodeRepository(AwfirContext context)
        {
            db = context;
        }

      
        public List<DealCodeModel> GetDiscountByCode(DealCodeModel dc)
        {
            try
            {
                List<DealCodeModel> abc = new List<DealCodeModel>();

                if (dc != null)
                {
                    var data = db.DealCodes.Where(x => x.Code == dc.Code && x.Status == true).FirstOrDefault();
                    if(data != null)
                    {
                        var record = db.DealCodes.Where(x =>x.Code == dc.Code && x.Validitydate >= DateTime.Now).FirstOrDefault();
                        if(record != null)
                        {
                            var result = db.FirstCouponCodes.Where(x => x.UserID == dc.UserID && x.Code == dc.Code).FirstOrDefault();
                            if(result == null)
                            {
                                var aa = db.DealCodes.Where(x => x.Code == dc.Code && x.DealID != null).FirstOrDefault();
                                if(aa != null)
                                {
                                    var bb = db.Offers.Where(x => x.DealID == aa.DealID).ToList();
                                    if(bb.Count() > 0)
                                    {   
                                        foreach(var item in bb)    
                                        {
                                            DealCodeModel model = new DealCodeModel();
                                            model.OfferID = item.ID;
                                            model.Discount = data.Discount;
                                            model.Description = data.Description;
                                            abc.Add(model);
                                            
                                        }
                                        return abc;
                                    }
                                    else
                                    {
                                        DealCodeModel model = new DealCodeModel();
                                        model.DealID = aa.DealID;
                                        model.Discount = aa.Discount;
                                        model.Description = aa.Description;
                                        abc.Add(model);
                                       
                                    }
                                    return abc;
                                }
                                else
                                {
                                    DealCodeModel model = new DealCodeModel();
                                    model.Discount = data.Discount;
                                    model.Description = data.Description;
                                    abc.Add(model);
                                    
                                }
                                return abc;
                            }
                            else
                            {
                                DealCodeModel model = new DealCodeModel();
                                model.Message = "You already used this code.";
                                abc.Add(model);
                               
                            }
                            return abc;
                        }
                        else
                        {
                            DealCodeModel model = new DealCodeModel();
                            model.Message = "This coupon code has expired.";
                            abc.Add(model);
                           
                        }
                        return abc;
                    }
                    else
                    {
                        DealCodeModel model = new DealCodeModel();
                        model.Message = "Code is disbled.";
                        abc.Add(model);
                    }
                    return abc;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
