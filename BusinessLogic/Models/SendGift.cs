using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    [Table("SendGift")]
    public class SendGift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [ForeignKey("User")]
        public Guid FromUserID { get; set; }
        public User User { get; set; }
        public string RecepientEmail { get; set; }
        public string Message { get; set; }
        [ForeignKey("Deal")]
        public Guid DealID { get; set; }
        public Deal Deal { get; set; }
        public DateTime DateToSend { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Total { get; set; }
        
    }
}