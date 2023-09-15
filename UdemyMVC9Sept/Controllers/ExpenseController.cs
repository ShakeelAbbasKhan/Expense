using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UdemyMVC9Sept.Data;
using UdemyMVC9Sept.Models;
using UdemyMVC9Sept.Models.ViewModels;

namespace UdemyMVC9Sept.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> itemList = _db.Expenses
            .Include(e => e.ExpenseType)         // it include the Expense Type Data which is shown in view
              .ToList();
            return View(itemList);
        }
        public IActionResult Create()
        {
            // this is one method to show the list by viewBag and select list and create.cshtml give
            // asp-items = "@ViewBag.viewBagListITems" from this show the list of items


            //IEnumerable<SelectListItem> selectListItems = _db.ExpenseTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});
            //ViewBag.viewBagListITems = selectListItems;

            //return View();

            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expenseVM);
        }

        // post Create

        // post create if not create a EpenseVM
        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public IActionResult Create(Expense obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // obj.ExpenseTypeId = 1;
        //        _db.Expenses.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");

        //    }
        //    return View(obj);

        //}

        // post create if create a EpenseVM
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(ExpenseVM obj)
        {
            if (ModelState.IsValid)
            {
                // obj.ExpenseTypeId = 1;
                _db.Expenses.Add(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }
        // Get Delete
        
        public IActionResult Delete(int? id)
        {
            if (id == null || id ==0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // post Delete

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            
                _db.Expenses.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }

        // Get update

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            // drop down

            IEnumerable<SelectListItem> selectListItems = _db.ExpenseTypes.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.viewBagListITems = selectListItems;


            return View(obj);
        }

        // post Update
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }
    }
}
