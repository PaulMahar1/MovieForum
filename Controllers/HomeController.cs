using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieForum.Data;
using MovieForum.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace MovieForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieForumContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;


        public HomeController(MovieForumContext context, ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var discussion = await _context.Discussion.Include(m => m.Comments).Include(m => m.ApplicationUser).ToListAsync();

            return View(discussion);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Profile(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            var discussions = await _context.Discussion
                .Where(d => d.ApplicationUserId == user.Id)
                .Include(m => m.Comments)
                .ToListAsync();

            ViewBag.Discussions = discussions;

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return View(user);
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
                                           .Include(m => m.ApplicationUser)
                                           .Include(m => m.Comments)
                                              .ThenInclude(c => c.ApplicationUser)
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
