using Smartdrive.Models;
using System.ComponentModel.DataAnnotations;

namespace Smartdrive.DTO.Partners
{
    public record PartnerRequest( 
        string PartName,
        string PartAddress,
        DateTime PartJoinDate,
        string PartAccountNo,
        string PartNpwp,
        int PartCityId,
        PartnerStatus PartStatus
     );
}
