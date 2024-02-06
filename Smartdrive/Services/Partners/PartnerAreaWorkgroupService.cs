using Smartdrive.DTO.Partners;
using Smartdrive.Helper;
using Smartdrive.Models;
using Smartdrive.Repositories.Partners;

namespace Smartdrive.Services.Partners
{
    public class PartnerAreaWorkgroupService : IPartnerAreaWorkgroupService
    {
        private readonly IPartnerAreaWorkgroupRepository _partnerAreaWorkgroupRepository;

        public PartnerAreaWorkgroupService(IPartnerAreaWorkgroupRepository partnerAreaWorkgroupRepository)
        {
            _partnerAreaWorkgroupRepository = partnerAreaWorkgroupRepository;
        }

        public async Task Create(PartnerAreaWorkgroupRequest request)
        {
            PartnerAreaWorkgroup area = new()
            {
                PawoArwgCode = request.PawoArwgCode,
                PawoPatrEntityid = request.PawoPatrEntityid,
                PawoUserEntityid = request.PawoUserEntityid,
                PawoStatus = nameof(PartnerStatus.ACTIVE)
            };
            await _partnerAreaWorkgroupRepository.Create(area);
        }

        public async Task Delete(
            int pawoPatrEntityid, 
            int pawoUserEntityid, 
            string pawoArwgCode
        )
        {
            var area = await FindById( pawoPatrEntityid, pawoUserEntityid, pawoArwgCode );
            await _partnerAreaWorkgroupRepository.Delete(area);
        }

        public async Task<PartnerAreaWorkgroup> FindById(
            int pawoPatrEntityid, 
            int pawoUserEntityid, 
            string pawoArwgCode
        )
        {
            var areaWorkgroup = await _partnerAreaWorkgroupRepository.FindById(
                pawoPatrEntityid, 
                pawoUserEntityid, 
                pawoArwgCode
            );
            if (areaWorkgroup is null)
            {
                throw new Exception($"patner area workgroup are not found");
            }
            return areaWorkgroup;
        }

        public async Task Update(
            int pawoPatrEntityid,
            int pawoUserEntityid,
            string pawoArwgCode, 
            UpdatePartnerAreaWorkgroupRequest request
        )
        {
            var areaWorkgroup = await FindById( 
                pawoPatrEntityid, 
                pawoUserEntityid,  
                pawoArwgCode 
            );
            if (areaWorkgroup is null)
            {
                throw new Exception($"patner area workgroup are not found");
            }
            areaWorkgroup.PawoStatus = request.statusAreaWorkgroup.ToString();
            await _partnerAreaWorkgroupRepository.Update(areaWorkgroup);
        }

        public async Task<PaginationResponse<PartnerAreaWorkGroupAggregate>> Paginate(PaginationRequest request)
        {
            var (result, count) = await _partnerAreaWorkgroupRepository.Paginate(request);
            PaginationResponse<PartnerAreaWorkGroupAggregate> pagination = new(request)
            {
                Count = count,
                Data = result
            };
            return pagination;
        }
    }
}
