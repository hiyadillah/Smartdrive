using Smartdrive.DTO.Payment;

namespace Smartdrive.Services.Payment
{
    public interface IFintechService
    {
        public List<FintechResponse> FindAll();
        public FintechResponse FindById(int id);
    }
}
