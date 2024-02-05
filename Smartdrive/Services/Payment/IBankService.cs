using Smartdrive.DTO.Payment;
using System.Diagnostics.Contracts;

namespace Smartdrive.Services.Payment
{
    public interface IBankService
    {
        public List<BankResponse> FindAll();
        public BankResponse FindById(int id);

        public BankResponse Create(int bankEntityId, string bankName, string bankDesc);
        public BankResponse Delete(int bankEntityId);

        public BankResponse Update(int id, string bankName, string bankDesc);

    }

}
