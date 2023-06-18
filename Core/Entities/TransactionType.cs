using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TransactionType
    {
        [Key]
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