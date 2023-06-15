using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Merchant
    {
        [Key]
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