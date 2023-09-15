using Microsoft.AspNetCore.Mvc;

namespace UdemyMVC9Sept.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("IndexByID/{id}")]
        //public IActionResult IndexByID(int id)
        //{

        //    Console.WriteLine("The Id is: " + id);
        //    return Ok(id);
        //}

        [HttpGet("indexbyid")]
        public IActionResult IndexByID([FromQuery] string values)
        {
            Console.WriteLine("The Value is: " + values);
            return Ok(values);
        }

        [HttpPost("saveHeader")]
        public IActionResult saveHeader([FromHeader] string requestID)
        {
            return Ok($"Got a header with requestID: {requestID}");

        }

        [HttpPost]
        public IActionResult saveImage([FromForm] string filename, [FromForm] IFormFile file)
        {
            return Ok("Success");
        }

    }
}
