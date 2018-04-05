﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    [Table("DealOrder")]
    public class DealOrder
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
        public Guid OrderNumber { get; set; }
        public DateTime DealOrderDate { get; set; }
        public int Status { get; set; }
     
    }
}