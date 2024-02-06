using Microsoft.EntityFrameworkCore;
using Smartdrive.Db;
using Smartdrive.Helper;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Partners
{
    public class PartnerAreaWorkgroupRepository : IPartnerAreaWorkgroupRepository
    {
        private readonly SmartdriveContext _context;

        public PartnerAreaWorkgroupRepository(SmartdriveContext context)
        {
            _context = context;
        }

        public async Task Create(PartnerAreaWorkgroup workgroup)
        {
            await _context.PartnerAreaWorkgroups.AddAsync(workgroup);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(PartnerAreaWorkgroup workgroup)
        {
            _context.PartnerAreaWorkgroups.Remove(workgroup);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PartnerAreaWorkgroup workgroup)
        {
            await Delete(workgroup);
            await Create(workgroup);
        }

        public async Task<( List<PartnerAreaWorkGroupAggregate> ,int)> Paginate(PaginationRequest request)
        {
            var query = _context.PartnerAreaWorkgroups
                .AsNoTracking()
                .Select(x => new
                {
                    x.PawoPatrEntityid,
                    x.PawoUserEntityid,
                    x.PawoArwgCode,
                    x.PawoStatus,
                    x.PawoArwgCodeNavigation.ArwgCity!.CityName,
                    x.PawoArwgCodeNavigation.ArwgCity.CityProv!.ProvName,
                    x.Pawo.PacoUserEntity.UserFullName,
                    x.PawoArwgCodeNavigation.ArwgCity.CityProv.ProvZones!.ZonesName
                });
            var count = await query.CountAsync();
            query = query
                .Skip(request.Offset)
                .Take(request.Limit);
            List<PartnerAreaWorkGroupAggregate> result = new();
            foreach (var item in query)
            {
                result.Add(
                    new PartnerAreaWorkGroupAggregate
                    {
                        PawoPatrEntityid = item.PawoPatrEntityid,
                        PawoUserEntityid = item.PawoUserEntityid,
                        PawoArwgCode = item.PawoArwgCode,
                        CityName = item.CityName,
                        ProvinceName = item.ProvName,
                        PartnerName = item.UserFullName,
                        ZoneName = item.ZonesName,
                        Status = item.PawoStatus
                    }
                );
            }
            return (result, count);

        }

        public async Task<PartnerAreaWorkgroup?> FindById(int PawoPatrEntityid, int PawoUserEntityid, string PawoArwgCode)
        {
            return await _context.PartnerAreaWorkgroups.FindAsync(PawoPatrEntityid, PawoArwgCode, PawoUserEntityid);
        }
    }
}

