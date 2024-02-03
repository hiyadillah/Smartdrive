using Smartdrive.DTO.Payment;
using Smartdrive.Models;
using Smartdrive.Repositories;

namespace Smartdrive.Services.Payment
{
    public class FintechService : IFintechService
    {
        private readonly IRepository<Fintech> _repo;
        public FintechService(IRepository<Fintech> repo)
        {
            _repo = repo;
        }

        public List<FintechResponse> FindAll()
        {
            var data = _repo.FindAll();
            List<FintechResponse> responses = new();
            foreach (var item in data)
            {
                FintechResponse a = new(item.FintEntityid, item.FintName, item.FintDesc);
                responses.Add(a);
            }

            return responses;
        }
    }

    public interface IFintechService
    {
        public List<FintechResponse> FindAll();
    }
}
