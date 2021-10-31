using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Author : ModelBase
    {
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(100)]
        public string? Image { get; set; }
        [StringLength(250)]
        public string? About { get; set; }
        public IEnumerable<Blog>? Blogs { get; set; }
    }
}
