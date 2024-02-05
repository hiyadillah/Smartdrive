using Smartdrive.DTO.Payment;

namespace Smartdrive.Repositories.Payment
{
    public interface IFintechRepo
    {
        public void Create(FintechResponse fintechResponse);
        public void Update(int id, FintechResponse fintechResponse);
        public void Delete(int id);
    }

}
