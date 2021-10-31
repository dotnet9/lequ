using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Category : ModelBase
    {
        [StringLength(30)]
        public string? Name { get; set; }
        public int? ParentID { get; set; }
        public Category? Parent { get; set; }

        public IEnumerable<Blog>? Blogs { get; set; }
    }
}
