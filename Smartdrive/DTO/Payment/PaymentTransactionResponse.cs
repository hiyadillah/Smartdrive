namespace Smartdrive.DTO.Payment
{
    public record PaymentTransactionResponse(string patrTrxNo, DateTime? patrCreatedDateTime, decimal? patrDebet, decimal? patrCredit, string? patrUsacAccountNoFrom, string? patrUsacAccountNoTo, string patrType, string patrInvoiceNo, string patrNotes);
}
