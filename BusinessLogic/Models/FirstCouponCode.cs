using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    [Table("FirstCouponCode")]
    public class FirstCouponCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("User")]
        public Guid UserID { get; set; }
        public User User { get; set; }
        public string Code { get; set; }
        [ForeignKey("PaymentDetail")]
        public Guid PaymentDetailID { get; set; }
        public PaymentDetail PaymentDetail { get; set; }
    }
}
