using Smartdrive.Models;

namespace Smartdrive.DTO.Partners
{
    public record PartnerAreaWorkgroupRequest(
        int PawoPatrEntityid,
        int PawoUserEntityid,
        string PawoArwgCode, 
        PartnerStatus statusAreaWorkgroup
    );
}
