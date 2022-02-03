using System;
using System.Collections.Generic;
using System.Text;

namespace Contract.Services
{
    interface IOnlinePayment 
    {
        double PaymentFee(Double amount);
        double Interest(double amount, int month);
    }
}
