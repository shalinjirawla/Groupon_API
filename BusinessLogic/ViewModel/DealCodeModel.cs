using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModel
{
    public class DealCodeModel
    {
        public Guid ID { get; set; }
        public Nullable<Guid> DealID { get; set; }
        public Nullable<Guid> UserID { get; set; }
        public Nullable<Guid> OfferID { get; set; }
        public string Code { get; set; }
        public Nullable<Guid> LocationID { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> Validitydate { get; set; }
    }
}
