using Smartdrive.DTO.Payment;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.Payment;

namespace Smartdrive.Services.Payment
{
    public class BankService : IBankService
    {
        private readonly IRepository<Bank> _repo;
        private readonly IBankRepo _bankRepo;
        public BankService(IRepository<Bank> repo, IBankRepo bankRepo)
        {
            _repo = repo;
            _bankRepo = bankRepo;
        }

        public BankResponse Create(int bankEntityId, string bankName, string bankDesc)
        {
            Bank bank = new();
            bank.BankEntityid = bankEntityId;
            bank.BankName = bankName;
            bank.BankDesc = bankDesc;

            BankResponse bankResponse = new(bankEntityId, bank.BankName, bank.BankDesc);

            _bankRepo.Create(bankResponse);

            return bankResponse;

        }

        public BankResponse FindById(int id)
        {
            var data = _repo.FindById(id);
            if (data == null)
                return null;

            BankResponse response = new(data.BankEntityid, data.BankName, data.BankDesc);

            return response;
        }

        List<BankResponse> IBankService.FindAll()
        {
            var data = _repo.FindAll();
            List<BankResponse> responses = new();
            foreach (var item in data)
            {
                BankResponse a = new(item.BankEntityid, item.BankName, item.BankDesc);
                responses.Add(a);
            }

            return responses;
        }
    }
}
