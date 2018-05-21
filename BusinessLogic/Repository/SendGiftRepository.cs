using BusinessLogic.Interface;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class SendGiftRepository : ISendGift
    {
        private readonly AwfirContext db;
        public SendGiftRepository(AwfirContext context)
        {
            db = context;
        }

        public SendGift sendGift(SendGift gift)
        {
            try
            {
                if(gift != null)
                {
                    SendGift record = new SendGift();
                    record.Name = gift.Name;
                    record.FromUserID = gift.FromUserID;
                    record.RecepientEmail = gift.RecepientEmail;
                    record.Message = gift.Message;
                    record.DealID = gift.DealID;
                    record.DateToSend = gift.DateToSend;
                    record.CreatedDate = DateTime.Now;
                    record.Total = gift.Total;
                    db.SendGifts.Add(record);
                    db.SaveChanges();
                    return (record);
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
