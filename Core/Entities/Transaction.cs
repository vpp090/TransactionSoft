using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public abstract class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public TransactionStatus Status { get; set; }

        public string CustomerEmail {get; set;}
        public string CustomerPhone {get; set;}
    }

    public enum TransactionStatus
    {
        Approved,
        Reversed,
        Refunded,
        Error
    }
}