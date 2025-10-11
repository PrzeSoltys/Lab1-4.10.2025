using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        private static readonly List<BlogArticleViewModel> _articles = new()
        {
            new BlogArticleViewModel { Id = "1", Title = "Welcome to my Blog.", Description = "Intro post about the blog.", Content = "Help!"},
            new BlogArticleViewModel { Id = "2", Title = "Learning ASP.NET MVC.", Description = "Baisics of ASP.NET MCV.", Content = "Help!"},
            new BlogArticleViewModel { Id = "3", Title = "Understanding Routing.", Description = "How routing works.", Content = "Help!"}
        };
        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(_articles);
        }
        public IActionResult Article(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var post = _articles.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (post == null) return NotFound();
            return View(post);
        }
        [HttpGet]
            public IActionResult Create()
            {
                return View(new CreateBlogArticleModel());
            }
        [HttpPost]
        public IActionResult Create(CreateBlogArticleModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Id)) return Content("Provide an ID.");
            var stored = new BlogArticleViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Content = model.Content
            };
            _articles.Add(stored);
            return RedirectToAction(nameof(Article), new {id = stored.Id });
        }
    }
}
