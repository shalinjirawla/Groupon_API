using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModel
{
    public class UpdateCartModel
    {
        public Guid ID { get; set; }
        public decimal Total { get; set; }
        public bool Status { get; set; }
        public int Qty { get; set; }
    }
}
