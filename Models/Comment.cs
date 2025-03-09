using System.ComponentModel.DataAnnotations.Schema;
using MovieForum.Data;

namespace MovieForum.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        // Foreign Key
        public int DiscussionId { get; set; }

        // Foreign key (AspNetUsers table)

        public string ApplicationUserId { get; set; } = string.Empty;

        public ApplicationUser? ApplicationUser { get; set; }

        // Navigation
        public Discussion? Discussion { get; set; }
    }
}
