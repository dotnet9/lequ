using System.ComponentModel.DataAnnotations;

namespace Lequ.Blog.Model.Models
{
    public class Blog : ModelBase
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ThumbnailImage { get; set; }
        public string? Image { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
