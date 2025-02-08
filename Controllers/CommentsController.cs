using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieForum.Data;
using MovieForum.Models;

namespace MovieForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly MovieForumContext _context;

        public CommentsController(MovieForumContext context)
        {
            _context = context;
        }

        // GET: Comments/Edit/5
        // POST: Comments/Edit/5     
        // GET: Comments/Delete/5      
        // POST: Comments/Delete/5
        // GET: Comments
        // GET: Comments/Details/5

        // GET: Comments/Create
        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["DiscussionId"] = id;
    
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Comments/Create/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("CommentId,Content,CreateDate")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.DiscussionId = id ?? comment.DiscussionId;

                _context.Add(comment);
                await _context.SaveChangesAsync();


                return RedirectToAction("DiscussionDetails", "Home", new { id = comment.DiscussionId });
            }

            ViewData["DiscussionId"] = new SelectList(_context.Discussion, "DiscussionId", "Title", comment.DiscussionId);

            return View(comment);
        }      

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.CommentId == id);
        }
    }
}
