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
            Task<long> getCreditId = repository.GetCreditId(getClientId);
            Task<string> getFullname = GetFullName(getClientId);
            Task<int> getPaidAmount = GetPaidAmount(await getCreditId);
            Task<int> getLeftToPay = GetLeftToPay(await getCreditId);
            
            return new CreditInfo
            {
                FullName = await getFullname,
                PaidAmount = await getPaidAmount, 
                LeftToPay = await getLeftToPay
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
            Task<DateTime> dateOfCredit = repository.GetDateOfCredit(creditId);
            Task<int> monthlyPayment = repository.GetMonthlyPayment(creditId);
            int months = 12 * (DateTime.Now.Year - dateOfCredit.Result.Year) + DateTime.Now.Month - dateOfCredit.Result.Month;
            return months * await monthlyPayment;
        }

        private async Task<int> GetCreditAmount(long creditId)
        {
            Task<int> creditAmount = repository.GetCreditAmount(creditId);
            return await creditAmount;
        }
    }
}
