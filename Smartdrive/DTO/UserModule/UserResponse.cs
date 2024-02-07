using Smartdrive.Models;

namespace Smartdrive.DTO.UserModule
{
    public record UserResponse(
        int UserEntityid,
        string? UserName,
        string? UserFullName,
        string UserEmail,
        string? UserBirthPlace,
        DateTime? UserBirthDate,
        string UserNationalId,
        string? UserNpwp,
        string? UserPhoto,
        DateTime? UserModifiedDate
        //RefreshToken RefreshTokens
        //ICollection<RefreshToken> RefreshTokens
    );
}
