using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    [Table("Deal")]
    public class Deal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("User")]
        public Guid UserID { get; set; }
        public User User { get; set; }
        public string URL { get; set; }

        [ForeignKey("Location")]
        public Guid LocationID { get; set; }
        public Location Location { get; set; }
        public string Details { get; set; }
        public string FinePrint { get; set; }
        public string Image { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryID { get; set; }
        public Category Category { get; set; } 
        public int TotalQty { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Boolean Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}