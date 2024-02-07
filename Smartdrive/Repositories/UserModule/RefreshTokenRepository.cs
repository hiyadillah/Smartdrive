using Smartdrive.Db;
using Smartdrive.DTO.UserModule;
using Smartdrive.Models;

namespace Smartdrive.Repositories.UserModule
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly SmartdriveContext _context;

        public RefreshTokenRepository(SmartdriveContext context)
        {
            _context = context;
        }

        public RefreshToken CreateRefreshToken(User user, string refToken)
        {
            RefreshToken refreshToken = new RefreshToken()
            {
                RetoUser = user,
                RetoExpireDate = DateTime.Now.AddDays(7),
                //RetoExpireDate = DateTime.Now.AddSeconds(60),
                RetoToken = refToken
            };

            _context.RefreshTokens.Add(refreshToken);
            _context.SaveChanges();

            return refreshToken;
        }

        public RefreshToken FindRefreshTokenByToken(string refToken)
        {
            RefreshToken rt = _context.RefreshTokens.Where(x => x.RetoToken == refToken)
                .OrderBy(x => x.RetoExpireDate)
                .LastOrDefault();

            return rt;
        }
    }
}
