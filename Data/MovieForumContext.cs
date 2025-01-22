using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieForum.Models;

namespace MovieForum.Data
{
    public class MovieForumContext : DbContext
    {
        public MovieForumContext (DbContextOptions<MovieForumContext> options)
            : base(options)
        {
        }

        public DbSet<MovieForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<MovieForum.Models.Comment> Comment { get; set; } = default!;
    }
}
