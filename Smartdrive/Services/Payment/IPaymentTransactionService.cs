﻿using Smartdrive.DTO.Payment;

namespace Smartdrive.Services.Payment
{
    public interface IPaymentTransactionService
    {
        public List<PaymentTransactionResponse> FindAll();
    }

}