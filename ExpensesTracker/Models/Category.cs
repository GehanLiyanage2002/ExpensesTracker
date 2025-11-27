using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesTracker.Models
{
    public class Category
    {

        
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public String Icon { get; set; }   = " ";

        [Column(TypeName = "nvarchar(10)")]
        public String Type { get; set; } = "Expense"; // Expense or Income
    }
}
