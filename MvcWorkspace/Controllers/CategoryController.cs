using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Data;
using MvcWorkspace.Models;

namespace MvcWorkspace.Controllers
{
    public class CategoryController : Controller
    {

        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseCategory> categories = _db.Categories;
            return View(categories);
        }

        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
            {
                //Add
                return View(new ExpenseCategory());
            }
            else
            {
                //Update
                var obj = _db.Categories.Find(id);
                return View(obj);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(ExpenseCategory category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    // Add DB
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                else
                {
                    // Update DB
                    _db.Categories.Update(category);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);

            if (category == null || id == 0)
            {

                return NotFound();
            }

            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
