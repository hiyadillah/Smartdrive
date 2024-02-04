using Azure;
using Smartdrive.DTO.Master;
using Smartdrive.DTO.Payment;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Services.Master;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Smartdrive.Services.Payment
{
    public class UserAccountsService : IUserAccountService
    {
        private readonly IRepository<UserAccount> _repo;
        public UserAccountsService(IRepository<UserAccount> repo)
        {
            _repo = repo;
        }

        public UserAccountResponse FindById(int id)
        {
            var data = _repo.FindById(id);
            if (data == null) return null;
            UserAccountResponse response = new(data.UsacId, data.UsacAccountno, data.UsacDebet, data.UsacCredit, data.UsacType);
            return response;
        }

        List<UserAccountResponse> IUserAccountService.FindAll()
        {
            var data = _repo.FindAll();
            List<UserAccountResponse> response = new();
            foreach (var item in data)
            {
                UserAccountResponse a = new(item.UsacId, item.UsacAccountno, item.UsacDebet, item.UsacCredit, item.UsacType);
                response.Add(a);
            }
            return response;
        }
    }
}
