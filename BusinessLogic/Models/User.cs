using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessLogic.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string EmailID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(6)]
        public string Gender { get; set; }
        [ForeignKey("Location")]
        public Guid LocationID { get; set; }
        public Location Location { get; set; }
        public DateTime? DOB { get; set; }
        public Guid Category { get; set; }
        public string Image { get; set; }
        public string GoogleID { get; set; }
        [MaxLength(50)]
        public string GoogleName { get; set; }
        public string FacebookID { get; set; }
        [MaxLength(50)]
        public string FacebookName { get; set; }
        public DateTime RegisteredDate { get; set; }

    }
}