namespace Smartdrive.DTO.Customer_Request
{
    public record CustomerRequestDto
    (
        int CreqEntityid,
        DateTime? CreqCreateDate,
        string? CreqStatus,
        string? CreqType,
        DateTime? CreqModifiedDate,
        int? CreqCustEntityid,
        int? CreqAgenEntityid

    );
}
