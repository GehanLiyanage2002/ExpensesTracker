using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesTracker.Models
{
    public class Transaction
    {
        
        public int TransactionId { get; set; }
        public int CategoryId { get; set; }
        public Category categoryId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [Column(TypeName = "nvarchar(10)")]
        public string? Note { get; set; }
    }
}
