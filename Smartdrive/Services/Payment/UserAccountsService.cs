using Smartdrive.DTO.Master;
using Smartdrive.DTO.Payment;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Services.Master;

namespace Smartdrive.Services.Payment
{
    public class UserAccountsService : IUserAccountService
    {
        private readonly IRepository<UserAccount> _repo;
        public UserAccountsService(IRepository<UserAccount> repo)
        {
            _repo = repo;
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
