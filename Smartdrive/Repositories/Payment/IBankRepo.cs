using Smartdrive.DTO.Payment;

namespace Smartdrive.Repositories.Payment
{
    public interface IBankRepo
    {
        public void Create(BankResponse bankResponse);
        public void Update(int id, BankResponse bankResponse);
        public void Delete(int id);
    }

}
