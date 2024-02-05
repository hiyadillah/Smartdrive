using Smartdrive.DTO.Payment;

namespace Smartdrive.Services.Payment
{
    public interface IFintechService
    {
        public List<FintechResponse> FindAll();
        public FintechResponse FindById(int id);
        public FintechResponse Create(string fintName, string fintDesc);
        public void Delete(int fintEntityId);
        public FintechResponse Update(int id, string fintName, string fintDesc);
    }
}
