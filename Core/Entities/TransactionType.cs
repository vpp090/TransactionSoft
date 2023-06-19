using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TransactionType
    {
        [Key]
        public int Id {get; set;}
       
        public string Name {get; set;}
    }

    public enum TType 
    {
        Authorize = 1,
        Charge,
        Refund,
        Reversal
    }
}