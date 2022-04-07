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
    public class ExpenseCategoriesController : Controller
    {
        private ApplicationDbContext _context;
        
        public ExpenseCategoriesController(ApplicationDbContext context)
        {
            _context = context;
            

        }

        
        public IActionResult Index()
        {
            return View( _context.ExpenseCategories.AsEnumerable());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.ExpenseCategories.Add(expenseCategory);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseCategory);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseCategory = _context.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return NotFound();
            }
            return View(expenseCategory);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  ExpenseCategory expenseCategory)
        {
            if (id != expenseCategory.ExCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.ExpenseCategories.Update(expenseCategory);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseCategoryExists(expenseCategory.ExCategoryId))
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
            return View(expenseCategory);
        }

       
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseCategory = _context.ExpenseCategories
                .FirstOrDefault(m => m.ExCategoryId == id);
            if (expenseCategory == null)
            {
                return NotFound();
            }

            return View(expenseCategory);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var expenseCategory =  _context.ExpenseCategories.Find(id);
            _context.ExpenseCategories.Remove(expenseCategory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseCategoryExists(int id)
        {
            return _context.ExpenseCategories.Any(e => e.ExCategoryId == id);
        }
    }
}
