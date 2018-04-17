using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    [Table("PaymentDetail")]
    public class PaymentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("User")]
        public Guid UserID { get; set; }
        public User User { get; set; }
        [ForeignKey("Deal")]
        public Guid DealID { get; set; }
        public Deal Deal { get; set; }
        public int PaymentType { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public Nullable<int> CVV { get; set; }
        public decimal Amount { get; set; }
        public DateTime PayDate { get; set; }
        public int Status { get; set; }
        public Nullable<Guid> OfferID { get; set; }
    }
}