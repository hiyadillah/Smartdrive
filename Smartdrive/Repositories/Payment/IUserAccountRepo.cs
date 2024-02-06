using Smartdrive.DTO.Payment;

namespace Smartdrive.Repositories.Payment
{
    public interface IUserAccountRepo
    {
        public void Create(int id, UserAccountResponse userAccountResponse);
        public void Update(int id, UserAccountResponse userAccountResponse);
        public void Delete(int id);
    }


}
