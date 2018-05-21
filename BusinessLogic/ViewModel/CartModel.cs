using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModel
{
    public class CartModel
    {
        public Guid ID { get; set; }
        public Nullable<Guid> DealID { get; set; }
        public Nullable<Guid> OfferID { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
        public string CouponCode { get; set; }
        public int PaymentType { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Price1 { get; set; }
        public Nullable<decimal> Discount1 { get; set; }
        
    }
}
