namespace Smartdrive.DTO.Payment
{
    public record UserAccountResponse(int usacId, string usacAccountNo, decimal? usacDebet, decimal? usacCredit, string usacType);

}
