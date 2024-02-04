using Smartdrive.DTO.Payment;

namespace Smartdrive.Services.Payment
{
    public interface IBankService
    {
        public List<BankResponse> FindAll();
        public BankResponse FindById(int id);
    }

}
