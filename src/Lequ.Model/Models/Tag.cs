using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Tag : ModelBase
    {
        [StringLength(30)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public List<BlogTag>? BlogTags { get; set; }
    }
}
