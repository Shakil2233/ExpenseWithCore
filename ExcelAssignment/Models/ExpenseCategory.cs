using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelAssignment.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int ExCategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string ExCategoryName { get; set; }
        public virtual IList<Expense> Expenses { get; set; }
    }
}
