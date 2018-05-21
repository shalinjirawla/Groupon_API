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
    public class CartRepository : ICart
    {
        private readonly AwfirContext db;
        public CartRepository(AwfirContext context)
        {
            db = context;
        }
        public List<CartModel> GetCartDealList(Guid id)
        {
            try
            {
                if (id != null)
                {
                    var query =
                                (from c in db.Carts
                                 join d in db.Deals on c.DealID equals d.ID into cd
                                 from d in cd.DefaultIfEmpty()
                                 join o in db.Offers on c.OfferID equals o.ID into dc
                                 from o in dc.DefaultIfEmpty()
                                 where (c.UserID == id && c.Status == true)
                                 group new { c, d }
                                 by new
                                 {
                                     c.ID,
                                     c.DealID,
                                     c.Qty,
                                     c.Total,
                                     c.CouponCode,
                                     c.OfferID,
                                     d.Image,
                                     d.Name,
                                     Price = d == null ? 0 : d.Price,
                                     Discount = d == null ? 0 : d.Discount,
                                     Price1 = o == null ? 0 : o.Price,
                                     Discount1 = o == null ? 0 : o.Discount,
                                     o.Text
                                 } into gr
                                 select new
                                 {
                                     ID = gr.Key.ID,
                                     DealID = gr.Key.DealID,
                                     OfferID = gr.Key.OfferID,
                                     Qty = gr.Key.Qty,
                                     Total = gr.Key.Total,
                                     CouponCode = gr.Key.CouponCode,
                                     Price = gr.Key.Price,
                                     Discount = gr.Key.Discount,
                                     Price1 = gr.Key.Price1,
                                     Discount1 = gr.Key.Discount1,
                                     Image = gr.Key.Image,
                                     Name = gr.Key.Name,
                                     Text = gr.Key.Text
                                 }).ToList();


                    List<CartModel> cartModel = new List<CartModel>();
                    foreach (var item in query)
                    {
                        CartModel acart = new CartModel();
                        acart.ID = item.ID;
                        acart.DealID = item.DealID;
                        acart.OfferID = item.OfferID;
                        acart.Qty = item.Qty;
                        acart.Total = item.Total;
                        acart.CouponCode = item.CouponCode;
                        acart.Price = item.Price;
                        acart.Discount = item.Discount;
                        acart.Price1 = item.Price1;
                        acart.Discount1 = item.Discount1;
                        acart.Name = item.Name;
                        acart.Text = item.Text;

                        if (item.Image == null )
                        {
                            var ids = Guid.Parse(item.OfferID.ToString());
                            var que = (from d in db.Deals
                                       join o in db.Offers
                                       on d.ID equals o.DealID
                                       where o.ID == ids
                                       select new
                                       {
                                           imagePath = d.Image,
                                           
                                       }).FirstOrDefault();
                            
                            foreach (string file in Directory.EnumerateFiles(System.Web.HttpContext.Current.Server.MapPath("/App_Data/Image/"), "*", SearchOption.AllDirectories))
                            {
                                if (file.Split('\\')[7] == que.imagePath.Split('\\')[2])
                                {
                                    var abc = new FileInfo(file);
                                    byte[] bytes = System.IO.File.ReadAllBytes(file);
                                    var newFile = "data:image/jpeg; base64," + Convert.ToBase64String(bytes);

                                    acart.Image = newFile;
                                    
                                }
                            }
                        }
                        else
                        {
                            foreach (string file in Directory.EnumerateFiles(System.Web.HttpContext.Current.Server.MapPath("/App_Data/Image/"), "*", SearchOption.AllDirectories))
                            {
                                if (file.Split('\\')[7] == item.Image.Split('\\')[2])
                                {
                                    var abc = new FileInfo(file);
                                    byte[] bytes = System.IO.File.ReadAllBytes(file);
                                    var newFile = "data:image/jpeg; base64," + Convert.ToBase64String(bytes);

                                    acart.Image = newFile;
                                }
                            }
                        }
                        

                        cartModel.Add(acart);
                    }
                    if (cartModel.Count() > 0)
                    {
                        return cartModel;
                    }
                    else
                    {
                        return null;
                    }
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

        public bool InsertDeal(Cart cartdeal)
        {
            try
            {
                if (cartdeal != null)
                {
                    Cart record;
                    if (cartdeal.DealID != null)
                    {
                        record =
                        (from C in db.Carts
                         where (C.DealID == cartdeal.DealID && C.UserID == cartdeal.UserID)
                          && (C.Status == true)
                         select C
                         ).FirstOrDefault();
                    }
                    else
                    {
                        record =
                        (from C in db.Carts
                         where (C.OfferID == cartdeal.OfferID && C.UserID == cartdeal.UserID)
                          && (C.Status == true)
                         select C
                         ).FirstOrDefault();

                    }

                    if (record != null)
                    {
                        record.Qty = cartdeal.Qty + record.Qty;
                        record.Total = cartdeal.Total + record.Total;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        Cart cart = new Cart();
                        cart.UserID = cartdeal.UserID;
                        cart.DealID = cartdeal.DealID;
                        cart.OfferID = cartdeal.OfferID;
                        cart.Qty = cartdeal.Qty;
                        cart.Total = cartdeal.Total;
                        db.Carts.Add(cart);
                        db.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CartPlusMinus(UpdateCartModel Updatecart)
        {
            try
            {
                if (Updatecart != null)
                {
                    var data = db.Carts.Where(x => x.ID == Updatecart.ID).FirstOrDefault();
                    if (data != null)
                    {
                        if (Updatecart.Status == true)
                        {
                            data.Total = (data.Total) + (Updatecart.Total);
                            data.Qty = data.Qty + 1;
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            data.Total = (data.Total) - (Updatecart.Total);
                            data.Qty = data.Qty - 1;
                            db.SaveChanges();
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteDealByID(Guid id)
        {
            try
            {
                if (id != null)
                {
                    var record = db.Carts.Where(x => x.ID == id).FirstOrDefault();
                    if (record != null)
                    {
                        db.Carts.Remove(record);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
