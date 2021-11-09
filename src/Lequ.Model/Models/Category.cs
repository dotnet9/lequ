using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Category : ModelBase
    {
        [StringLength(30)] public string? Name { get; set; }

        [StringLength(500)] public string? Description { get; set; }

        public int? ParentID { get; set; }

        public Category? Parent { get; set; }

        public List<BlogCategory>? BlogCategories { get; set; }
    }
}