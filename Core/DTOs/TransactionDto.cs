namespace Core.DTOs
{
    public class TransactionDto
    {
        public Guid Id {get; set;}
        public decimal Amount {get; set;}

        public int TransactionTypeId {get; set;}

        public string CustomerPhone {get; set;}
        public string CustomerEmail {get; set;}

        public int MerchantId {get; set;}

        public TransStatus Status {get; set;}
    }

    public enum TransStatus
    {
        Approved,
        Reversed,
        Refunded,
        Error
    }

    public class TransactionType
    {
        public int Id {get; set;}
        public TType TType {get; set;}

        public string Name {get; set;}
    }

    public enum TType 
    {
        Authorize,
        Charge,
        Refund,
        Reversal
    }
}