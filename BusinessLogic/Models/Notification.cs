using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    [Table("Notification")]
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("Deal")]
        public Guid DealID { get; set; }
        public Deal Deal { get; set; }
        public DateTime CreatedTime { get; set; }
        [MaxLength(250)]
        public string Message { get; set; }
     }
}