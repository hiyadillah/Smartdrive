using Smartdrive.Helper;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Partners
{
    public interface IPartnerAreaWorkgroupRepository
    {
        Task Create(PartnerAreaWorkgroup workgroup);
        Task Delete(PartnerAreaWorkgroup workgroup);
        Task Update(PartnerAreaWorkgroup workgroup);
        Task<PartnerAreaWorkgroup?> FindById(int PawoPatrEntityid, int PawoUserEntityid, string PawoArwgCode);
        Task<(List<PartnerAreaWorkGroupAggregate>, int)> Paginate(PaginationRequest request);
    }
}
