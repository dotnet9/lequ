using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Link : ModelBase
    {
        [StringLength(20)] public string? Name { get; set; }

        [StringLength(100)] public string? Url { get; set; }

        [StringLength(500)] public string? Description { get; set; }

        public int Index { get; set; }
    }
}