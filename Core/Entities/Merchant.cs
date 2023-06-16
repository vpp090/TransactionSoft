using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Merchant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public MerchantStatus Status { get; set; }

        public decimal TotalTransactionSum {get; set;}
    }

    public enum MerchantStatus
    {
        Active,
        Inactive
    }
}