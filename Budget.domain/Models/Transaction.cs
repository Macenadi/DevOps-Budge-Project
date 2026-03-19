using System.ComponentModel.DataAnnotations;

namespace Budget.domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        [Range(0.01, 999999999)]
        public decimal Amount { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string UserId { get; set; } = string.Empty;
    }
}