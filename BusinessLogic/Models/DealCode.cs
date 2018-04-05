using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    [Table("DealCode")]
    public class DealCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("Deal")]
        public Guid DealID { get; set; }
        public Deal Deal { get; set; }
        [ForeignKey("User")]
        public Guid UserID { get; set; }
        public User User { get; set; }
        public string Code { get; set; }
        [ForeignKey("Location")]
        public Guid LocationID { get; set; }
        public Location Location { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Validitydate { get; set; }
        
    }
}