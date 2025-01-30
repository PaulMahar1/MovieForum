using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieForum.Models
{
    public class Discussion
    {
        public int DiscussionId { get; set; }
        public string Title { get; set; } = string.Empty;

        //public string Username { get; set; } = string.Empty ;
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Thumbnail")]
        public string? ImageFilename { get; set; }

        [Display(Name = "Created")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? ImageFile { get; set; } // Nullable for optional file uploads

        // Navigation
        public List<Comment>? Comments { get; set; }
    }
}
