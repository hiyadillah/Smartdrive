using Smartdrive.DTO.Partners;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Partners
{
    public interface IPartnertContactRepository
    {
        Task Create(PartnertContactRequest request);
        Task Update(UpdatePartnerContactRequest contact, int userId);
        Task Delete(PartnerContact contact);
        Task<PartnerContact?> FindByid(int partnerId, int userId);
    }
}
