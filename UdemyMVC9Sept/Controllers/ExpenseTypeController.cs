using Microsoft.AspNetCore.Mvc;
using UdemyMVC9Sept.Data;
using UdemyMVC9Sept.Models;

namespace UdemyMVC9Sept.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ExpenseType> itemList = _db.ExpenseTypes;
            return View(itemList);
        }
        public IActionResult Create()
        {

            return View();
        }

        // post Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }
        // Get Delete

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // post Delete

        [HttpPost]
        
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int id)
        {
            var obj = _db.ExpenseTypes.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            
                _db.ExpenseTypes.Remove(obj);
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
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // post Update
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }
    }
}
