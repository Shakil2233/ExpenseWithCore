
using ExcelAssignment.AttributeFile.ValidationDate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;

namespace ExcelAssignment.Models
{
    public class Expense
    {
        [Key]
        public int ExId { get; set; }
        public int ExCategoryId_FK { get; set; }
        [Required, Today, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
       
        public DateTime ExDate { get; set; }
        [Required]
        public decimal ExAmount { get; set; }
        [ForeignKey("ExCategoryId_FK")]
        public ExpenseCategory ExpenseCategories { get; set; }
    }
}
