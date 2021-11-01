using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Tag : ModelBase
    {
        [StringLength(30)]
        public string? Name { get; set; }

        public List<BlogTag>? BlogTags { get; set; }
    }
}
