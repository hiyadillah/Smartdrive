using Smartdrive.DTO.Payment;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.Payment;

namespace Smartdrive.Services.Payment
{
    public class FintechService : IFintechService
    {
        private readonly IRepository<Fintech> _repo;
        private readonly IFintechRepo _fintechRepo;
        public FintechService(IRepository<Fintech> repo, IFintechRepo fintechRepo)
        {
            _repo = repo;
            _fintechRepo = fintechRepo;
        }

        public FintechResponse Create(string fintName, string fintDesc)
        {
            FintechResponse fintechResponse = new(0, fintName, fintDesc);
            _fintechRepo.Create(fintechResponse);
            return fintechResponse;
        }

        public void Delete(int fintEntityId)
        {
            var fint = _repo.FindById(fintEntityId);
            if (fint == null)
            {
                return;
            }
            _fintechRepo.Delete(fintEntityId);

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

        public FintechResponse FindById(int id)
        {
            var data = _repo.FindById(id);
            if (data == null)
                return null;

            FintechResponse response = new(data.FintEntityid, data.FintName, data.FintDesc);

            return response;
        }

        public FintechResponse Update(int id, string fintName, string fintDesc)
        {
            var data = _repo.FindById(id);
            if (data == null)
                return null;

            FintechResponse newResponse = new(data.FintEntityid, fintName, fintDesc);
            _fintechRepo.Update(id, newResponse);

            return newResponse;
        }
    }
}
