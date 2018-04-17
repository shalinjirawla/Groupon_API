using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModel
{
    public class AllDeal
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid UserID { get; set; }
        public string URL { get; set; }
        public Guid LocationID { get; set; }
        public string LocationName { get; set; }
        public string Details { get; set; }
        public string FinePrint { get; set; }
        public string Image { get; set; }
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int TotalQty { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Boolean Status { get; set; }
        public Nullable<Int32> DealSold { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<decimal> AverageRating { get; set; }
        public Nullable<int> RateCount { get; set; }

    }
    public class DealLikeIDs
    {
        public Guid DealID { get; set; }
        public Guid UserID { get; set; }
    }
}
