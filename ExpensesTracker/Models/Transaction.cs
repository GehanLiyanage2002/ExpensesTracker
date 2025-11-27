namespace ExpensesTracker.Models
{
    public class Transaction
    {
        
        public int TransactionId { get; set; }
        public int CategoryId { get; set; }
        public Category categoryId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? Note { get; set; }
    }
}
