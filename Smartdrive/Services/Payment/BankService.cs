using Smartdrive.DTO.Payment;
using Smartdrive.Models;
using Smartdrive.Repositories;

namespace Smartdrive.Services.Payment
{
    public class BankService : IBankService
    {
        private readonly IRepository<Bank> _repo;
        public BankService(IRepository<Bank> repo)
        {
            _repo = repo;
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
