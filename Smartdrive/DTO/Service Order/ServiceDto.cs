using Smartdrive.Models;

namespace Smartdrive.DTO.Service_Order
{
    public record ServiceDto
    (
        DateTime? ServCreatedOn,
        string? ServType,
        string? ServInsuranceNo,
        string? ServVehicleNo,
        DateTime? ServStartdate,
        DateTime? ServEnddate,
        string? ServStatus,
        User? ServCustEntity,
        Service? ServServ,
        CustomerRequest? ServCreqEntity
    );
}
