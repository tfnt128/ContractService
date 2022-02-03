using Contract.Entities;
using System;

namespace Contract.Services
{
    class ContractService
    {
        private IOnlinePayment _IOnlinePayment;

        public ContractService(IOnlinePayment iOnlinePayment)
        {
            _IOnlinePayment = iOnlinePayment;
        }

        public void ProcessContract(Contracts contract, int month)
        {
            double basicQuota = contract.TotalValue / month;
            for(int i = 1;i <= month; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updatedQuota = basicQuota + _IOnlinePayment.Interest(basicQuota, i);
                double fullQuota = updatedQuota + _IOnlinePayment.PaymentFee(updatedQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
