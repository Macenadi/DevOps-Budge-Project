using System.ComponentModel.DataAnnotations;

namespace Budget.domain.Models
{
    public enum IncomeCategory
    {
        Salary,
        Freelance,
        Investment,

        [Display(Name = "Other Income")]
        OtherIncome
    }
}