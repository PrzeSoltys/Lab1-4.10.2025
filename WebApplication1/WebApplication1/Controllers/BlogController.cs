using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(new BlogViewModel()
            {
                Title = "Welcome to My Blog!",
                Description = "Tis is a simple blog application built with ASP.MCV."
            });
        }
    }
}
