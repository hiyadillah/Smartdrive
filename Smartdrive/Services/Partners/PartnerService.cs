using Smartdrive.DTO.Partners;
using Smartdrive.Helper;
using Smartdrive.Models;
using Smartdrive.Repositories.Partners;

namespace Smartdrive.Services.Partners
{
    public class PartnerService: IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnerService(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task Create(PartnerRequest request)
        {
            Partner partner = new()
            {
                PartName = request.PartName,
                PartAccountNo = request.PartAccountNo,
                PartAddress = request.PartAddress,
                PartCityId = request.PartCityId,
                PartModifiedDate = DateTime.Now,
                PartJoinDate = request.PartJoinDate,
                PartNpwp = request.PartNpwp,
                PartStatus = request.PartStatus.ToString(),

            };
            await _partnerRepository.Create(partner);
        }

        public async Task Delete(int id)
        {
            Partner? partner = await _partnerRepository.FindById(id);
            if(partner is null)
            {
                throw new Exception($"partner with id {id} not found");
            }
            await _partnerRepository.Delete(partner);
        }

        public async Task<Partner?> IsPartnerExist(int id)
        {
            var partner = await _partnerRepository.FindById(id);
            if (partner is null)
            {
                throw new Exception($"partner with id {id} is not found");
            }
            return partner;
        }

        public async Task<PaginationResponse<PartnerResponse>> Paginate(PaginationRequest request)
        {
            var (result, count) = await _partnerRepository.Paginate(request);
            List<PartnerResponse> data = new();
            foreach (var item in result)
            {
                data.Add(
                    new PartnerResponse(
                        item.PartEntityid,
                        item.PartName,
                        item.PartAddress,
                        item.PartJoinDate,
                        item.PartAccountNo,
                        item.PartNpwp,
                        item.PartStatus,
                        item.PartCityId
                    )
                );
            }

            PaginationResponse<PartnerResponse> pagination = new(request)
            {
                Data = data,
                Count = count
            };
            return pagination;
        }

        public async Task Update(PartnerRequest request, int id)
        {
            Partner? partner = await _partnerRepository.FindById(id);
            if (partner is null)
            {
                throw new Exception($"partner with id {partner!.PartEntityid} is not found");
            }

            partner.PartEntityid = id;
            partner.PartName = request.PartName;
            partner.PartAccountNo = request.PartAccountNo;
            partner.PartAddress = request.PartAddress;
            partner.PartCityId = request.PartCityId;
            partner.PartJoinDate = request.PartJoinDate;
            partner.PartNpwp = request.PartNpwp;
            partner.PartStatus = request.PartNpwp.ToString();

            await _partnerRepository.Update(partner);
        }

    }
}
