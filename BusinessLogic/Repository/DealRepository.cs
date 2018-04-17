using BusinessLogic.ViewModel;
using BusinessLogic.Interface;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace BusinessLogic.Repository
{
    public class DealRepository : IDeal
    {
        private readonly AwfirContext db;
        public DealRepository(AwfirContext context)
        {
            db = context;
        }

        public List<AllDeal> GetHotDeal()
        {
            try
            {
                var deal = (from d in db.Deals
                             join DR in db.DealRecoms
                             on new { ID = d.ID }
                             equals new { ID = DR.DealID }
                             where (d.Status == true)
                             group new { d, DR } by new
                             {
                                 d.ID,
                                 d.Name,
                                 d.UserID,
                                 d.URL,
                                 d.LocationID,
                                 d.Details,
                                 d.Image,
                                 d.FinePrint,
                                 d.CategoryID,
                                 d.TotalQty,
                                 d.Price,
                                 d.Discount,
                                 d.Status,
                                 d.CreatedDate,
                                 DR.AverageRating,
                                 DR.TotalLikes
                             } into gr
                             select new
                             {
                                 ID = gr.Key.ID,
                                 Name = gr.Key.Name,
                                 UserID = gr.Key.UserID,
                                 URL = gr.Key.URL,
                                 LocationID = gr.Key.LocationID,
                                 Details = gr.Key.Details,
                                 FinePrint = gr.Key.FinePrint,
                                 Image = gr.Key.Image,
                                 CategoryID = gr.Key.CategoryID,
                                 TotalQty = gr.Key.TotalQty,
                                 Price = gr.Key.Price,
                                 Discount = gr.Key.Discount,
                                 Status = gr.Key.Status,
                                 CreatedDate = gr.Key.CreatedDate,
                                 TotalLikes = gr.Key.TotalLikes,
                                 AverageRating = gr.Key.AverageRating
                             }).OrderByDescending(x => x.Discount).Take(3).ToList();

                List<AllDeal> dealdata = new List<AllDeal>();

                foreach (var item in deal)
                {
                    AllDeal dealList = new AllDeal();
                    dealList.ID = item.ID;
                    dealList.Name = item.Name;
                    dealList.UserID = item.UserID;
                    dealList.URL = item.URL;
                    dealList.LocationID = item.LocationID;
                    dealList.Details = item.Details;
                    dealList.FinePrint = item.FinePrint;
                    dealList.CategoryID = item.CategoryID;
                    dealList.TotalQty = item.TotalQty;
                    dealList.Price = item.Price;
                    dealList.Discount = item.Discount;
                    dealList.Status = item.Status;
                    dealList.CreatedDate = item.CreatedDate;
                    dealList.AverageRating = item.AverageRating;
                    var query = db.DealReviews.Where(x => x.DealID == item.ID).ToList().Count();
                    dealList.RateCount = query;

                    foreach (string file in Directory.EnumerateFiles(System.Web.HttpContext.Current.Server.MapPath("/App_Data/Image/"), "*", SearchOption.AllDirectories))
                    {
                        if (file.Split('\\')[7] == item.Image.Split('\\')[2])
                        {
                            var abc = new FileInfo(file);
                            byte[] bytes = System.IO.File.ReadAllBytes(file);
                            var newFile = "data:image/jpeg; base64," + Convert.ToBase64String(bytes);

                            dealList.Image = newFile;
                        }
                    }

                    dealdata.Add(dealList);
                }
                if (deal != null)
                {
                    return dealdata;
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

        public IEnumerable<AllDeal> GetTrendingDeal()
        {
            try
            {
                 var deal = (from d in db.Deals
                           join p in db.PaymentDetails
                           on new { ID = d.ID }
                           equals new { ID = p.DealID }
                           join r in db.DealRecoms 
                           on new { ID = d.ID }
                           equals new { ID = r.DealID }
                           where (d.Status == true)
                           group new { d, p } by new
                           {
                               p.DealID,
                               d.ID,    
                               d.Name,
                               d.UserID,
                               d.URL,
                               d.LocationID,
                               d.Details,
                               d.FinePrint,
                               d.Image,
                               d.CategoryID,
                               d.TotalQty,
                               d.Price,
                               d.Discount,
                               d.Status,
                               d.CreatedDate,
                               r.TotalLikes,
                               r.AverageRating,
                               

                           } into gr
                           select new
                           {
                               ID = gr.Key.ID,
                               Name = gr.Key.Name,
                               UserID = gr.Key.UserID,
                               URL = gr.Key.URL,
                               LocationID = gr.Key.LocationID,
                               Details = gr.Key.Details,
                               FinePrint = gr.Key.FinePrint,
                               Image = gr.Key.Image,
                               CategoryID = gr.Key.CategoryID,
                               TotalQty = gr.Key.TotalQty,
                               Price = gr.Key.Price,
                               Discount = gr.Key.Discount,
                               Status = gr.Key.Status,
                               CreatedDate = gr.Key.CreatedDate,
                               TotalLikes = gr.Key.TotalLikes,
                               AverageRating = gr.Key.AverageRating,
                               Count = gr.Count()
                           }).OrderByDescending(x=>x.Count).Take(3).ToList();

                List<AllDeal> TLIST = new List<AllDeal>();

                foreach (var item in deal)
                {
                    AllDeal a = new AllDeal();
                    a.ID = item.ID;
                    a.Name = item.Name;
                    a.UserID = item.UserID;
                    a.URL = item.URL;
                    a.LocationID = item.LocationID;
                    a.Details = item.Details;
                    a.FinePrint = item.FinePrint;
                    a.CategoryID = item.CategoryID;
                    a.TotalQty = item.TotalQty;
                    a.Price = item.Price;
                    a.Discount = item.Discount;
                    a.Status = item.Status;
                    a.CreatedDate = item.CreatedDate;
                    a.AverageRating = item.AverageRating;
                    var query = db.DealReviews.Where(x => x.DealID == item.ID).ToList().Count();
                    a.RateCount = query;

                    foreach (string file in Directory.EnumerateFiles(System.Web.HttpContext.Current.Server.MapPath("/App_Data/Image/"), "*", SearchOption.AllDirectories))
                    {
                        if (file.Split('\\')[7] == item.Image.Split('\\')[2])
                        {
                            var abc = new FileInfo(file);
                            byte[] bytes = System.IO.File.ReadAllBytes(file);
                            var newFile = "data:image/jpeg; base64," + Convert.ToBase64String(bytes);

                            a.Image = newFile;
                        }
                    }
                    TLIST.Add(a);
                }
                
                if (TLIST != null)
                {
                    return TLIST;
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

        public IEnumerable<AllDeal> GetRecommendedDeal()
        {
            try
            {
                var deal = (from d in db.Deals
                            join DR in db.DealRecoms
                            on new { ID = d.ID }
                            equals new { ID = DR.DealID}
                            where (d.Status == true)
                            group new { d, DR } by new
                            {
                                DR.DealID,
                                d.ID,
                                d.Name,
                                d.UserID,
                                d.URL,
                                d.LocationID,
                                d.Details,
                                d.FinePrint,
                                d.Image,
                                d.CategoryID,
                                d.TotalQty,
                                d.Price,
                                d.Discount,
                                d.Status,
                                d.CreatedDate,
                                DR.TotalLikes,
                                DR.AverageRating

                            }
                             into gr
                            select new
                            {
                                ID = gr.Key.ID,
                                Name = gr.Key.Name,
                                UserID = gr.Key.UserID,
                                URL = gr.Key.URL,
                                LocationID = gr.Key.LocationID,
                                Details = gr.Key.Details,
                                FinePrint = gr.Key.FinePrint,
                                Image = gr.Key.Image,
                                CategoryID = gr.Key.CategoryID,
                                TotalQty = gr.Key.TotalQty,
                                Price = gr.Key.Price,
                                Discount = gr.Key.Discount,
                                Status = gr.Key.Status,
                                CreatedDate = gr.Key.CreatedDate,
                                TotalLikes = gr.Key.TotalLikes,
                                AverageRating = gr.Key.AverageRating,
                                Total = gr.Sum(x=>x.DR.AverageRating + x.DR.TotalLikes + x.DR.TotalReviews)
                              
                            }).OrderByDescending(x => x.Total).Take(3).ToList();

                List<AllDeal> RLIST = new List<AllDeal>();

                foreach (var item in deal)
                {
                    AllDeal a = new AllDeal();
                    a.ID = item.ID;
                    a.Name = item.Name;
                    a.UserID = item.UserID;
                    a.URL = item.URL;
                    a.LocationID = item.LocationID;
                    a.Details = item.Details;
                    a.FinePrint = item.FinePrint;
                    a.CategoryID = item.CategoryID;
                    a.TotalQty = item.TotalQty;
                    a.Price = item.Price;
                    a.Discount = item.Discount;
                    a.Status = item.Status;
                    a.CreatedDate = item.CreatedDate;
                    a.AverageRating = item.AverageRating;
                    var query = db.DealReviews.Where(x => x.DealID == item.ID).ToList().Count();
                    a.RateCount = query;

                    foreach (string file in Directory.EnumerateFiles(System.Web.HttpContext.Current.Server.MapPath("/App_Data/Image/"), "*", SearchOption.AllDirectories))
                    {
                        if (file.Split('\\')[7] == item.Image.Split('\\')[2])
                        {
                            var abc = new FileInfo(file);
                            byte[] bytes = System.IO.File.ReadAllBytes(file);
                            var newFile = "data:image/jpeg; base64," + Convert.ToBase64String(bytes);

                            a.Image = newFile;
                        }
                    }
                    RLIST.Add(a);
                }


                if (RLIST != null)
                {
                    return RLIST;
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

        public IEnumerable<AllDeal> GetRecentlyDeal()
        {
            try
            {
                var deal =  (from d in db.Deals
                             join DR in db.DealRecoms
                             on new { ID = d.ID }
                             equals new { ID = DR.DealID }
                             where (d.Status == true)
                             group new { d, DR } by new
                             {
                                 d.ID,
                                 d.Name,
                                 d.UserID,
                                 d.URL,
                                 d.LocationID,
                                 d.Details,
                                 d.Image,
                                 d.FinePrint,
                                 d.CategoryID,
                                 d.TotalQty,
                                 d.Price,
                                 d.Discount,
                                 d.Status,
                                 d.CreatedDate,
                                 DR.AverageRating,
                                 DR.TotalLikes
                             } into gr
                             select new
                             {
                                 ID = gr.Key.ID,
                                 Name = gr.Key.Name,
                                 UserID = gr.Key.UserID,
                                 URL = gr.Key.URL,
                                 LocationID = gr.Key.LocationID,
                                 Details = gr.Key.Details,
                                 FinePrint = gr.Key.FinePrint,
                                 Image = gr.Key.Image,
                                 CategoryID = gr.Key.CategoryID,
                                 TotalQty = gr.Key.TotalQty,
                                 Price = gr.Key.Price,
                                 Discount = gr.Key.Discount,
                                 Status = gr.Key.Status,
                                 CreatedDate = gr.Key.CreatedDate,
                                 TotalLikes = gr.Key.TotalLikes,
                                 AverageRating = gr.Key.AverageRating
                             }).OrderByDescending(x => x.ID).Take(3).ToList();

                List<AllDeal> dealdata = new List<AllDeal>();

                foreach (var item in deal)
                {
                    AllDeal dealList = new AllDeal();
                    dealList.ID = item.ID;
                    dealList.Name = item.Name;
                    dealList.UserID = item.UserID;
                    dealList.URL = item.URL;
                    dealList.LocationID = item.LocationID;
                    dealList.Details = item.Details;
                    dealList.FinePrint = item.FinePrint;
                    dealList.CategoryID = item.CategoryID;
                    dealList.TotalQty = item.TotalQty;
                    dealList.Price = item.Price;
                    dealList.Discount = item.Discount;
                    dealList.Status = item.Status;
                    dealList.CreatedDate = item.CreatedDate;
                    dealList.AverageRating = item.AverageRating;
                    var query = db.DealReviews.Where(x => x.DealID == item.ID).ToList().Count();
                    dealList.RateCount = query;

                    foreach (string file in Directory.EnumerateFiles(System.Web.HttpContext.Current.Server.MapPath("/App_Data/Image/"), "*", SearchOption.AllDirectories))
                    {
                        if (file.Split('\\')[7] == item.Image.Split('\\')[2])
                        {
                            var abc = new FileInfo(file);
                            byte[] bytes = System.IO.File.ReadAllBytes(file);
                            var newFile = "data:image/jpeg; base64," + Convert.ToBase64String(bytes);

                            dealList.Image = newFile;
                        }
                    }

                    dealdata.Add(dealList);
                }

                if (deal != null)
                {
                    return dealdata;
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

        public AllDeal GetByID(Guid id)
        {
            try
            {
                var data = db.Deals.Where(x => x.ID == id).FirstOrDefault();

                AllDeal record = new AllDeal();
                if (data != null)
                {
                    var a = db.Locations.Where(x => x.ID == data.LocationID).Select(x => x.LocationName).FirstOrDefault();
                    var cat = db.Categorys.Where(x => x.ID == data.CategoryID).Select(x => x.CategoryName).FirstOrDefault();
                    var image = "";
                    foreach (string file in Directory.EnumerateFiles(System.Web.HttpContext.Current.Server.MapPath("/App_Data/Image/"), "*", SearchOption.AllDirectories))
                    {
                        if (file.Split('\\')[7] == data.Image.Split('\\')[2])
                        {
                            var abc = new FileInfo(file);
                            byte[] bytes = System.IO.File.ReadAllBytes(file);
                            var newFile = "data:image/jpeg; base64," + Convert.ToBase64String(bytes);

                            image = newFile;
                        }
                    }

                    record.ID = data.ID;
                    record.Name = data.Name;
                    record.UserID = data.UserID;
                    record.URL = data.URL;
                    record.LocationName = a;
                    record.Details = data.Details;
                    record.FinePrint = data.FinePrint;
                    record.Image = image;
                    record.CategoryName = cat;
                    record.TotalQty = data.TotalQty;
                    record.Price = data.Price;
                    record.Discount = data.Discount;
                    record.Status = data.Status;
                    record.CreatedDate = data.CreatedDate;
                    record.DealSold = data.DealSold;
                    return record;
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
