using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Merchant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address is not a valid")]
        public string Email { get; set; }
        public MerchantStatus Status { get; set; }
       
         public ICollection<Transaction> Transactions {get; set;}

        public decimal TotalTransactionSum => Transactions != null ? Transactions.Where(t => t.Merchant.Id == Id)
                                                                                 .Where(t => t.TransactionType.Id == (int)TType.Charge)
                                                                                 .Where(t => t.Status == TransactionStatus.Approved)
                                                                                 .Where(t => t.IsProcessed == true)
                                                                                 .Sum(t => t.Amount) : 0;
    }

    public enum MerchantStatus
    {
        Active,
        Inactive
    }
}