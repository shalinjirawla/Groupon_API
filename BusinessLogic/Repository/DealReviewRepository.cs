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
    public class DealReviewRepository : IDealReview
    {
        private readonly AwfirContext db;
        public DealReviewRepository(AwfirContext context)
        {
            db = context;
        }

        public IEnumerable<DealReviewModel> GetAllReviews(Guid id)
        {
            try
            {
                var count = db.DealReviews.Where(x => x.DealID == id).Count();   
                 var data = (from dr in db.DealReviews
                            join u in db.Users
                            on new { ID = dr.UserID }
                            equals new { ID = u.ID }
                            where dr.DealID == id
                            group new { dr, u } by new
                            {
                                dr.ID,
                                dr.DealID,
                                dr.Rating,
                                dr.ReviewDate,
                                dr.ReviewText,
                                dr.UserID,
                                u.FirstName,
                                u.LastName,
                                u.Image

                            } into gr
                            select new
                            {
                                ID = gr.Key.ID,
                                DealID = gr.Key.DealID,
                                UserID = gr.Key.UserID,
                                Rating = gr.Key.Rating,
                                ReviewText = gr.Key.ReviewText,
                                ReviewDate = gr.Key.ReviewDate,
                                Image = gr.Key.Image,
                                FullName = gr.Key.FirstName + " " + gr.Key.LastName,

                            }).ToList();
            

                List<DealReviewModel> result = new List<DealReviewModel>();

                foreach (var item in data)
                {
                    DealReviewModel model = new DealReviewModel();
                    model.ID = item.ID;
                    model.DealID = item.DealID;
                    model.FullName = item.FullName;
                    model.Rating = item.Rating;
                    model.ReviewText = item.ReviewText;
                    model.UserID = item.UserID;
                    model.ReviewDate = item.ReviewDate;
                    foreach (string file in Directory.EnumerateFiles(System.Web.HttpContext.Current.Server.MapPath("/App_Data/Image/"), "*", SearchOption.AllDirectories))
                    {
                        if (file.Split('\\')[7] == item.Image.Split('\\')[2])
                        {
                            var abc = new FileInfo(file);
                            byte[] bytes = System.IO.File.ReadAllBytes(file);
                            var newFile = "data:image/jpeg; base64," + Convert.ToBase64String(bytes);

                            model.Image = newFile;
                        }
                    }
                    result.Add(model);
                }
                if (result != null)
                {
                    return result;
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

        public string InsertDealReview(DealReview dealReview)
        {
            try
            {
                if(dealReview != null)
                {
                    DealReview DR = new DealReview();
                    DR.DealID = dealReview.DealID;
                    DR.ReviewText = dealReview.ReviewText;
                    DR.Rating = dealReview.Rating;
                    DR.UserID = dealReview.UserID;
                    DR.ReviewDate = DateTime.Now;
                    db.DealReviews.Add(DR);
                    db.SaveChanges();
                    return ("Ok"); 
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
