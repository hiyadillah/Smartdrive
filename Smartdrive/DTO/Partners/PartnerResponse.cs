namespace Smartdrive.DTO.Partners
{
    public record PartnerResponse(
        int PartEntityid,
        string? PartName,
        string? PartAddress,
        DateTime? PartJoinDate,
        string? PartAccountNo, 
        string? PartNpwp, 
        string? PartStatus,
        int PartCityId 
    );
}
