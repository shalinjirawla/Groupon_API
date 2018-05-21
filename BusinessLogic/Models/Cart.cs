using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    [Table("Cart")]
    public class Cart
    {
        public Cart()
        {
            this.Status = true;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Nullable<Guid> DealID { get; set; }
        public Nullable<Guid> OfferID { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
        public string CouponCode { get; set; }
        public Nullable<int> PaymentType { get; set; }
        [ForeignKey("User")]
        public Guid UserID { get; set; }
        public User User { get; set; }
        public bool Status { get; set; }
     }
}