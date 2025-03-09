using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieForum.Models;

namespace MovieForum.Data
{
    public class MovieForumContext : IdentityDbContext<ApplicationUser>
    {
        public MovieForumContext (DbContextOptions<MovieForumContext> options)
            : base(options)
        {
        }

        public DbSet<MovieForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<MovieForum.Models.Comment> Comment { get; set; } = default!;
    }
}
