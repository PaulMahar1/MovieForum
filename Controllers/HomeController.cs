using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieForum.Data;
using MovieForum.Models;

namespace MovieForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieForumContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(MovieForumContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var discussion = await _context.Discussion.Include(m => m.Comments).ToListAsync();

            return View(discussion);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("Home/DiscussionDetails/{id:int}")]
        public async Task<IActionResult> DiscussionDetails(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Discussion ID was null.");
                return NotFound();
            }

            var discussion = await _context.Discussion
                                           .Include(m => m.Comments)
                                           .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussion == null)
            {
                _logger.LogWarning($"Discussion with ID {id} not found.");
                return NotFound();
            }

            return View(discussion);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
