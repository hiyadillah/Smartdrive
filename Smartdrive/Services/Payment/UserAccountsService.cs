using Azure;
using Smartdrive.DTO.Master;
using Smartdrive.DTO.Payment;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.Payment;
using Smartdrive.Services.Master;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Smartdrive.Services.Payment
{
    public class UserAccountsService : IUserAccountService
    {
        private readonly IRepository<UserAccount> _repo;
        private readonly IUserAccountRepo _userAccountRepo;
        public UserAccountsService(IRepository<UserAccount> repo, IUserAccountRepo userAccountRepo)
        {
            _repo = repo;
            _userAccountRepo = userAccountRepo;
        }

        public UserAccountResponse Create(int userId, string accountNo, decimal? usacDebet, decimal? usacCredit, string usacType)
        {
            UserAccountResponse response = new(0, accountNo, usacDebet, usacCredit, usacType);

            _userAccountRepo.Create(userId, response);
            return response;
        }

        public void Delete(int id)
        {
            var data = _repo.FindById(id);
            if (data == null)
                return;

            _userAccountRepo.Delete(id);

        }

        public UserAccountResponse FindById(int id)
        {
            var data = _repo.FindById(id);
            if (data == null) return null;
            UserAccountResponse response = new(data.UsacId, data.UsacAccountno, data.UsacDebet, data.UsacCredit, data.UsacType);
            return response;
        }

        public UserAccountResponse Update(int usacId, string accountNo, decimal? usacDebet, decimal? usacCredit, string usacType)
        {
            var data = _repo.FindById(usacId);
            if (data == null)
            {
                return null;
            }

            UserAccountResponse response = new(data.UsacId, accountNo, usacDebet, usacCredit, usacType);
            _userAccountRepo.Update(usacId, response);
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
