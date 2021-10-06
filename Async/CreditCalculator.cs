using System;
using System.Threading.Tasks;

namespace Async
{
    internal class CreditCalculator
    {
        private readonly Repository repository = new Repository();

        public async Task<CreditInfo> Calculate()
        {
            int clientId = await repository.GetClientId();
            Task<long> creditId = repository.GetCreditId(clientId);
            Task<string> fullname = GetFullName(clientId);
            Task<int> paidAmount = GetPaidAmount(creditId.Result);
            Task<int> leftToPay = GetLeftToPay(creditId.Result);
            
            return new CreditInfo
            {
                FullName = fullname.Result,
                PaidAmount = paidAmount.Result, 
                LeftToPay = leftToPay.Result
            };
        }

        private async Task<string> GetFullName(int clientId)
        {
            Task<string> getfirstName = repository.GetFirstName(clientId);
            Task<string> getlastName = repository.GetLastName(clientId);
            return $"{await  getfirstName} {await getlastName}";
        }

        private async Task<int> GetLeftToPay(long creditId)
        {
            Task<int> creditAmount = GetCreditAmount(creditId);
            Task<double> interestCharges = GetInterestCharges(creditId);
            Task<int> paidAmount = GetPaidAmount(creditId);
            var left = await creditAmount + await interestCharges - await paidAmount;
            return (int)left;
        }

        private async Task<double> GetInterestCharges(long creditId)
        {
            Task<int> creditAmount = GetCreditAmount(creditId);
            Task<int> monthlyRate = repository.GetMonthlyRate(creditId);
            Task<int> creditTerm = repository.GetCreditTerm(creditId);
            return await creditAmount * await monthlyRate / 100 * await creditTerm;
        }

        private async Task<int> GetPaidAmount(long creditId)
        {
            DateTime dateOfCredit = repository.GetDateOfCredit(creditId);
            int months = 12 * (DateTime.Now.Year - dateOfCredit.Year) + DateTime.Now.Month - dateOfCredit.Month;
            Task<int> monthlyPayment = repository.GetMonthlyPayment(creditId);
            return months * await monthlyPayment;
        }

        private async Task<int> GetCreditAmount(long creditId)
        {
            Task<int> creditAmount = repository.GetCreditAmount(creditId);
            return await creditAmount;
        }
    }
}
