using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModel
{
    public class DealReviewModel
    {
        public Guid ID { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public Guid DealID { get; set; }
        public Guid UserID { get; set; }
        public DateTime ReviewDate { get; set; }
        public string FullName { get; set; }
        
        public string Image { get; set; }
    }
}
