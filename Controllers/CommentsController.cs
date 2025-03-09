using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieForum.Data;
using MovieForum.Models;
using Microsoft.AspNetCore.Identity;

namespace MovieForum.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly MovieForumContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(MovieForumContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Comments/Edit/5
        // POST: Comments/Edit/5     
        // GET: Comments/Delete/5      
        // POST: Comments/Delete/5
        // GET: Comments
        // GET: Comments/Details/5

        // GET: Comments/Create
        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //string userId = _userManager.GetUserId(User);

            //var discussion = await _context.Discussion             
            //    .FirstOrDefaultAsync(m => m.DiscussionId == id);

            //if (discussion == null)
            //{
            //    return NotFound();
            //}

            //ViewData["DiscussionId"] = id;
            var comment = new Comment { DiscussionId = (int)id };
            Console.WriteLine(comment.DiscussionId);
            return View(comment);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Content,CreateDate,DiscussionId")] Comment comment)
        {

            if (ModelState.IsValid)
            {


                var userId = _userManager.GetUserId(User);

                comment.ApplicationUserId = userId;


                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("DiscussionDetails", "Home", new { id = comment.DiscussionId });
            }

            return View(comment);
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.CommentId == id);
        }
    }
}
