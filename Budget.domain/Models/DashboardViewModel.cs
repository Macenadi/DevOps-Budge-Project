using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.domain.Models
{
    public class DashboardViewModel
    {
        public decimal TotalBalance { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpenses { get; set; }

        public List<Transaction> RecentTransactions { get; set; } = new();

        public Dictionary<string, decimal> ExpenseBreakdown { get; set; } = new();
    }
}