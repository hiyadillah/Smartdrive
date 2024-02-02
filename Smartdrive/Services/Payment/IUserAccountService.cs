using Smartdrive.DTO.Payment;

namespace Smartdrive.Services.Payment
{
    public interface IUserAccountService
    {
        List<UserAccountResponse> FindAll();
    }
}
