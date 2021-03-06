﻿using System;
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
        public DealCode()
        {
            this.Status = true;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Nullable<Guid> DealID { get; set; }
        public Nullable<Guid> UserID { get; set; }
        public string Code { get; set; }
        public Nullable<Guid> LocationID { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> Validitydate { get; set; }
        
    }
}