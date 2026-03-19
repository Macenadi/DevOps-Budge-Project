using Budget.domain.Models;
using BudgetWise.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetWise.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var transactions = _context.Transactions
                .OrderByDescending(t => t.Date)
                .ToList();

            var totalIncome = transactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);

            var totalExpenses = transactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);

            var totalBalance = totalIncome - totalExpenses;

            var expenseBreakdown = transactions
                .Where(t => t.Type == TransactionType.Expense)
                .GroupBy(t => t.Category)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Amount));

            var model = new DashboardViewModel
            {
                TotalBalance = totalBalance,
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                RecentTransactions = transactions.Take(6).ToList(),
                ExpenseBreakdown = expenseBreakdown
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TransactionTypes = new SelectList(Enum.GetValues(typeof(TransactionType)));

            // default categories (Expense)
            ViewBag.Categories = new SelectList(Enum.GetValues(typeof(ExpenseCategory)));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TransactionTypes = new SelectList(Enum.GetValues(typeof(TransactionType)));
                ViewBag.Categories = new SelectList(Enum.GetValues(typeof(ExpenseCategory)));
                return View(transaction);
            }

            transaction.UserId = "demo";

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}