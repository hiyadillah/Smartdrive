namespace Smartdrive.DTO.Customer_Request
{
    public record AddCustomerRequestDto
    (
        DateTime? CreqCreateDate,
        string? CreqStatus,
        string? CreqType,
        DateTime? CreqModifiedDate,
        int? CreqCustEntityid,
        int? CreqAgenEntityid
    );
}
