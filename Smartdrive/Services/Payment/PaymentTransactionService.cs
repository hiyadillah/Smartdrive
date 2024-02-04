using Smartdrive.DTO.Payment;
using Smartdrive.Models;
using Smartdrive.Repositories;

namespace Smartdrive.Services.Payment
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly IRepository<PaymentTransaction> _repo;

        public PaymentTransactionService(IRepository<PaymentTransaction> repo)
        {
            _repo = repo;
        }

        public List<PaymentTransactionResponse> FindAll()
        {
            var data = _repo.FindAll();
            List<PaymentTransactionResponse> responses = new();
            foreach (var item in data)
            {
                PaymentTransactionResponse response = new(item.PatrTrxno, item.PatrCreatedOn, item.PatrDebet, item.PatrCredit, item.PatrUsacAccountNoFrom, item.PatrUsacAccountNoTo, item.PatrType, item.PatrInvoiceNo, item.PatrNotes);
                responses.Add(response);
            }
            return responses;
        }

        public PaymentTransactionResponse FindById(string id)
        {
            var data = _repo.FindById(id);
            if (data == null)
                return null;

            PaymentTransactionResponse response = new(data.PatrTrxno, data.PatrCreatedOn, data.PatrDebet, data.PatrCredit, data.PatrUsacAccountNoFrom, data.PatrUsacAccountNoTo, data.PatrType, data.PatrInvoiceNo, data.PatrNotes);
            return response;
        }
    }

}
