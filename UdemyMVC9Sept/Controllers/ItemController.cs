using Microsoft.AspNetCore.Mvc;
using UdemyMVC9Sept.Data;
using UdemyMVC9Sept.Models;

namespace UdemyMVC9Sept.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> itemList = _db.Items;
            return View(itemList);
        }
        public IActionResult Create()
        {

            return View();
        }

        // post Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
