using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lequ.Blog.Model
{
    public class Category : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ParentID { get; set; }
        public Category? Parent { get; set; }

        public List<Blog>? Blogs { get; set; }
    }
}
