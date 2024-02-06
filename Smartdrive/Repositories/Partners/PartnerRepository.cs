using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Smartdrive.Db;
using Smartdrive.Helper;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Partners
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly SmartdriveContext _context;

        public PartnerRepository(SmartdriveContext context)
        {
            _context = context;
        }

        public async Task Create(Partner partner)
        {
            using var context = _context;
            using var transaction = context.Database.BeginTransaction();
            try
            {
                BusinessEntity businessEntity = new()
                {
                    EntityModifiedDate = DateTime.Now,
                };
                await context.BusinessEntities.AddAsync(businessEntity);
                await context.SaveChangesAsync();
                partner.PartEntity = businessEntity;
                await context.Partners.AddAsync(partner);
                await context.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task Delete(Partner partner)
        {
            BusinessEntity entity = new()
            {
                Entityid = partner.PartEntityid
            };
            _context.BusinessEntities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Partner?> FindById(int id)
        {
            return await _context.Partners.FindAsync(id);
        }

        public async Task<(List<Partner>, int)> Paginate(PaginationRequest paginationOptions)
        {
             IQueryable<Partner> query = _context.Partners.AsNoTracking().Where(x => x.PartName!.Contains(paginationOptions.Search));
            int count = await query.CountAsync();
            query = query
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit);
            List<Partner> result = await query.ToListAsync();
            return (result, count);
        }

        public async Task Update(Partner partner)
        {
            _context.Entry(partner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
