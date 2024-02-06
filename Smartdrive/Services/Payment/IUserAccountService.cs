using Smartdrive.DTO.Payment;

namespace Smartdrive.Services.Payment
{
    public interface IUserAccountService
    {
        public List<UserAccountResponse> FindAll();
        public UserAccountResponse FindById(int id);
        public UserAccountResponse Create(int id, string accountNo, decimal? usacDebet, decimal? usacCredit, string usacType);
        public UserAccountResponse Update(int id, string accountNo, decimal? usacDebet, decimal? usacCredit, string usacType);
        public void Delete(int id);
    }

}
