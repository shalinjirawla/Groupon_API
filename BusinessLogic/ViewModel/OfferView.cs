using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModel
{
    public class OfferView
    {
        public Guid OfferID { get; set; }
        public Guid DealID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Image { get; set; }
    }
}
