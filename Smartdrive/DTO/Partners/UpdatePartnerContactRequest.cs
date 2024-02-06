namespace Smartdrive.DTO.Partners
{
    public record UpdatePartnerContactRequest(
        string OldContact, 
        string NewContact, 
        string OldPhone,
        string NewPhone
     );
}
