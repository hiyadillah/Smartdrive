using Smartdrive.DTO.Partners;
using Smartdrive.Models;
using Smartdrive.Repositories.Partners;

namespace Smartdrive.Services.Partners
{
    public class PartnerContactService : IPartnerContactService
    {
        private readonly IPartnertContactRepository _partnerContactRepository;
        private readonly IPartnerService _partnerService;

        public PartnerContactService(IPartnertContactRepository partnerContactRepository, IPartnerService partnerService)
        {
            _partnerContactRepository = partnerContactRepository;
            _partnerService = partnerService;
        }

        public async Task Create(PartnertContactRequest request)
        {
            _ = await _partnerService.IsPartnerExist(request.PartnerId);
            await _partnerContactRepository.Create(request);
        }

        public async Task Delete(int partnerId, int userId)
        {
            await IsContactExist(partnerId, userId);
            PartnerContact contact = new()
            {
                PacoUserEntityid = userId,
                PacoPatrnEntityid = partnerId,
            };
            await _partnerContactRepository.Delete(contact);
        }

        public async Task Update(int partnerId, int userId, UpdatePartnerContactRequest request)
        {
            await IsContactExist(partnerId, userId);
            await _partnerContactRepository.Update(request, userId);

        }

        public async Task IsContactExist(int partnerId, int userId)
        {
            var contact = await _partnerContactRepository.FindByid(partnerId, userId);
            if(contact is null)
            {
                throw new Exception($"contact with id partner ${partnerId} and userId {userId} Not Found");
            }
        }
    }
}
