namespace Smartdrive.DTO.Customer_Request
{
    public record UpdateCustomerRequestDto
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
