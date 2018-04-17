using BusinessLogic.Models;
using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IPaymentDetail
    {
        IEnumerable<PaymentDetailCount> GetDealIDCount(Guid id);
        PaymentDetail InsertPayment(PaymentDetail detail);
    }
}
