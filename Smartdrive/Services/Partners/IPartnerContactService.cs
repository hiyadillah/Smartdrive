using Smartdrive.DTO.Partners;

namespace Smartdrive.Services.Partners
{
    public interface IPartnerContactService
    {
        Task Create(PartnertContactRequest request);
        Task Delete(int partnerId, int userId);
        Task Update(int partnerId, int userId, UpdatePartnerContactRequest request);
    }
}
