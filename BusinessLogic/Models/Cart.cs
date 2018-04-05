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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("Deal")]
        public Guid DealID { get; set; }
        public Deal Deal { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
        public string CouponCode { get; set; }
        public int PaymentType { get; set; }
        [ForeignKey("User")]
        public Guid UserID { get; set; }
        public User User { get; set; }
        public int Status { get; set; }
     }
}