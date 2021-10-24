using System.ComponentModel.DataAnnotations;

namespace Lequ.Blog.EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}
