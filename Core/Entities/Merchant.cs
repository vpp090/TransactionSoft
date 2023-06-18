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
        public decimal TotalTransactionSum {get; set;}

        public ICollection<Transaction> Transactions {get; set;}
    }

    public enum MerchantStatus
    {
        Active,
        Inactive
    }
}