using Smartdrive.DTO.UserModule;
using Smartdrive.Models;

namespace Smartdrive.Repositories.UserModule
{
    public interface IRefreshTokenRepository
    {
        RefreshToken CreateRefreshToken(User user, string refToken);
        RefreshToken FindRefreshTokenByToken(string refToken);
    }
}
