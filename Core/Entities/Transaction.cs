using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range((double)1, (double)decimal.MaxValue, ErrorMessage = "The amount should be greater than 0")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "TransactionStatus is required")]
        public TransactionStatus Status { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address is not a valid")]
        public string CustomerEmail {get; set;}

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression("^[0-9]{10}$")]
        public string CustomerPhone {get; set;}

        [Column(TypeName="Datetime")]
        public DateTime CreatedDate {get; set;}
        
        public TransactionType TransactionType {get; set;}

        public Merchant Merchant {get; set;}

        public Guid LinkedTransactionId {get; set;}

        public bool IsProcessed {get; set;}
    }

    public enum TransactionStatus
    {
        Approved = 1,
        Reversed,
        Refunded,
        Error
    }
}