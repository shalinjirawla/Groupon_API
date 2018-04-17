using BusinessLogic.Interface;
using BusinessLogic.Models;
using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Repository
{
    public class OffersRepository : IOffers
    {
        private readonly AwfirContext db;
        public OffersRepository(AwfirContext context)
        {
            db = context;
        }

        public IEnumerable<Offers> DealOffers(Guid id)
        {
            try
            {
                var record = db.Offers.Where(x => x.DealID == id).ToList();
                if(record != null)
                {
                    return record;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        public OfferView OfferOrDealByID(OfferIDDealID offerIDDealID)
        {
            try
            {

                if (offerIDDealID.OfferID != null && offerIDDealID.DealID != null)
                {
                    var record = (from o in db.Offers
                                  join D in db.Deals
                                  on new { ID = o.DealID }
                                  equals new { ID = D.ID }
                                  where (o.ID == offerIDDealID.OfferID)
                                  group new { o, D } by new
                                  {
                                      o.ID,
                                      o.DealID,
                                      o.Text,
                                      o.Price,
                                      o.Discount,
                                      D.Image
                                  }
                                   into od
                                  select new
                                  {
                                      ID = od.Key.ID,
                                      DealID = od.Key.DealID,
                                      Text = od.Key.Text,
                                      Price = od.Key.Price,
                                      Discount = od.Key.Discount,
                                      Image = od.Key.Image
                                  }).FirstOrDefault();

                    OfferView result = new OfferView();
                    result.ID = record.ID;
                    result.DealID = record.DealID;
                    result.Text = record.Text;
                    result.Price = record.Price;
                    result.Discount = record.Discount;
                    var image = "";
                    foreach (string file in Directory.EnumerateFiles(System.Web.HttpContext.Current.Server.MapPath("/App_Data/Image/"), "*", SearchOption.AllDirectories))
                    {
                        if (file.Split('\\')[7] == record.Image.Split('\\')[2])
                        {
                            var abc = new FileInfo(file);
                            byte[] bytes = System.IO.File.ReadAllBytes(file);
                            var newFile = "data:image/jpeg; base64," + Convert.ToBase64String(bytes);

                            image = newFile;
                        }
                    }
                    result.Image = image;
                    return result;
                }
                else if (offerIDDealID.OfferID != null || offerIDDealID.DealID != null)
                {
                    var record = db.Deals.Where(x => x.ID == offerIDDealID.DealID).FirstOrDefault();
                    OfferView offerView = new OfferView();
                    offerView.ID = record.ID;
                    offerView.Name = record.Name;
                    offerView.Price = record.Price;
                    offerView.Discount = record.Discount;
                    var image = "";
                    foreach (string file in Directory.EnumerateFiles(System.Web.HttpContext.Current.Server.MapPath("/App_Data/Image/"), "*", SearchOption.AllDirectories))
                    {
                        if (file.Split('\\')[7] == record.Image.Split('\\')[2])
                        {
                            var abc = new FileInfo(file);
                            byte[] bytes = System.IO.File.ReadAllBytes(file);
                            var newFile = "data:image/jpeg; base64," + Convert.ToBase64String(bytes);

                            image = newFile;
                        }
                    }
                    offerView.Image = image;
                    return offerView;
                }
                else {
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
