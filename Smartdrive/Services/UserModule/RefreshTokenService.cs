using Smartdrive.DTO.UserModule;
using Smartdrive.Models;
using Smartdrive.Repositories.UserModule;
using System.Security.Cryptography;

namespace Smartdrive.Services.UserModule
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepo;
        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepo)
        {
            _refreshTokenRepo = refreshTokenRepo;
        }
        public RefreshToken GenerateRefreshToken(User user)    
        {
            var newRefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            var refreshToken = _refreshTokenRepo.CreateRefreshToken(user, newRefreshToken);

            return refreshToken;
        }

        public RefreshToken FindRefreshTokenByToken(string refreshToken) { 
            var refToken = _refreshTokenRepo.FindRefreshTokenByToken(refreshToken);

            if (refreshToken == null) return null;
            
            return refToken;
        }
    }
}
