using Smartdrive.DTO.Payment;

namespace Smartdrive.Services.Payment
{
    public interface IUserAccountService
    {
        public List<UserAccountResponse> FindAll();

        public UserAccountResponse FindById(int id);
    }

}
