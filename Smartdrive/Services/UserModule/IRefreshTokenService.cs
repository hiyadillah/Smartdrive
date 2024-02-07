using Smartdrive.DTO.UserModule;
using Smartdrive.Models;

namespace Smartdrive.Services.UserModule
{
    public interface IRefreshTokenService
    {
        RefreshToken GenerateRefreshToken(User user);
        RefreshToken FindRefreshTokenByToken(string refreshToken);
    }
}
