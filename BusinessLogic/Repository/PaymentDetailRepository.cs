using BusinessLogic.Interface;
using BusinessLogic.Models;
using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class PaymentDetailRepository : IPaymentDetail
    {
        private readonly AwfirContext db;
        public PaymentDetailRepository(AwfirContext context)
        {
            db = context;
        }
        public IEnumerable<PaymentDetailCount> GetDealIDCount(Guid id)
        {
            try
            {
                var result = db.PaymentDetails.Where(x => x.DealID == id).Select(x => x.DealID).ToList().Count();
                List<PaymentDetailCount> record = new List<PaymentDetailCount>();
               
                PaymentDetailCount found = new PaymentDetailCount();
                found.DealID = id;
                found.Count = result;
                record.Add(found);
                
                if (record != null)
                {
                    return record;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public PaymentDetail InsertPayment(PaymentDetail detail)
        {
            try
            {
                if(detail != null)
                {
                    PaymentDetail result = new PaymentDetail();
                    result.UserID = detail.UserID;
                    result.DealID = detail.DealID;
                    result.PaymentType = detail.PaymentType;
                    result.CardNumber = detail.CardNumber;
                    result.CardName = detail.CardName;
                    result.ExpiryDate = detail.ExpiryDate;
                    result.CVV = detail.CVV;
                    result.Amount = detail.Amount;
                    result.PayDate = DateTime.Now;
                    result.Status = detail.Status;
                    result.OfferID = detail.OfferID;
                    db.PaymentDetails.Add(result);
                    db.SaveChanges();

                    return detail;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
