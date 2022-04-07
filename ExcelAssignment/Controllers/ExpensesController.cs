using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExcelAssignment.Models;
using Microsoft.AspNetCore.Hosting;

namespace ExcelAssignment.Controllers
{
    public class ExpensesController : Controller
    {
        private  ApplicationDbContext _context;
        IWebHostEnvironment _webHostEnvironment;

        public ExpensesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Expenses
        public IActionResult Index(DateTime? StartDate,DateTime? EndDate)
        {
            var exp = _context.Expenses.Include(m => m.ExpenseCategories);
            if (StartDate.HasValue && EndDate.HasValue)
            {
                return View(
                    exp.Where(w => w.ExDate >= StartDate && w.ExDate <= EndDate).AsEnumerable()
                    );
            }
            else
            {
                return View(exp.AsEnumerable());
            }


        }





        public IActionResult Create()
        {
            ViewData["ExCategoryId_FK"] = new SelectList(_context.ExpenseCategories, "ExCategoryId", "ExCategoryName");
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExCategoryId_FK"] = new SelectList(_context.ExpenseCategories, "ExCategoryId", "ExCategoryName", expense.ExCategoryId_FK);
            return View(expense);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = _context.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["ExCategoryId_FK"] = new SelectList(_context.ExpenseCategories, "ExCategoryId", "ExCategoryName", expense.ExCategoryId_FK);
            return View(expense);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Expense expense)
        {
            if (id != expense.ExId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.ExId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExCategoryId_FK"] = new SelectList(_context.ExpenseCategories, "ExCategoryId", "ExCategoryName", expense.ExCategoryId_FK);
            return View(expense);
        }

        
        public IActionResult Delete(int? id)
        {

            try

            {

                var firstEntity = _context.Expenses.Where(c => c.ExId == id).FirstOrDefault();

                _context.Expenses.Remove(firstEntity);

                _context.SaveChanges();

            }

            finally

            {



            }

            return RedirectToAction("Index");

        }


        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.ExId == id);
        }
    }
}
