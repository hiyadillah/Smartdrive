namespace Smartdrive.DTO.UserModule
{
    public record UserRequest(
        string? UserName,
        string? UserFullName,
        string UserPassword,
        string UserEmail,
        string? UserBirthPlace,
        DateTime? UserBirthDate,
        string UserNationalId,
        string? UserNpwp
    );
}
