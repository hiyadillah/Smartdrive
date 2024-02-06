namespace Smartdrive.DTO.UserModule
{
    public record UserResponse(
        int UserEntityId,
        string? UserName,
        string? UserFullName,
        string UserEmail,
        string? UserBirthPlace,
        DateTime? UserBirthDate,
        string UserNationalId,
        string? UserNpwp,
        string? UserPhoto,
        DateTime? UserModifiedDate
    );
}
