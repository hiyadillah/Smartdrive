namespace Smartdrive.DTO.Partners
{
    public record PartnertContactRequest(
        string ContactName,
        string PhoneNumber,
        bool IsGrantedUser,
        int PartnerId
    );
    
   
}
