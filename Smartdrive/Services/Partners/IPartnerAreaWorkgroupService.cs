using Smartdrive.DTO.Partners;
using Smartdrive.Helper;
using Smartdrive.Models;

namespace Smartdrive.Services.Partners
{
    public interface IPartnerAreaWorkgroupService
    {
        Task Create(PartnerAreaWorkgroupRequest request);
        Task Delete(
            int PawoPatrEntityid, 
            int PawoUserEntityid, 
            string PawoArwgCode
        );

        Task Update(
            int pawoPatrEntityid,
            int pawoUserEntityid,
            string pawoArwgCode,
            UpdatePartnerAreaWorkgroupRequest request
        );
        Task<PartnerAreaWorkgroup> FindById(
            int PawoPatrEntityid, 
            int PawoUserEntityid, 
            string PawoArwgCode
        );

        Task<PaginationResponse<PartnerAreaWorkGroupAggregate>> Paginate(PaginationRequest request);
    }
}
