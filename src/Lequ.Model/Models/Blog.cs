using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Blog : ModelBase
    {
        [StringLength(100)]
        public string? Title { get; set; }
        [StringLength(100)]
        public string? Image { get; set; } 
        public string? Content { get; set; }
        public int AuthorID { get; set; }
        public Author? Author { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Comment>? Comments { get; set; }
    }
}
