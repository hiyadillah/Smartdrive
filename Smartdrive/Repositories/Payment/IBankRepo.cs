using Smartdrive.DTO.Payment;

namespace Smartdrive.Repositories.Payment
{
    public interface IBankRepo
    {
        public void Create(BankResponse bankResponse);
        public void Update(BankResponse bankResponse);
        public void Delete(BankResponse bankResponse);
    }
}
