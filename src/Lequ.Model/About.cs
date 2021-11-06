using System.ComponentModel.DataAnnotations;

namespace Lequ.Model
{
    public class About : ModelBase
    {
        [StringLength(500)]
        public string? Details1 { get; set; }

        [StringLength(500)]
        public string? Details2 { get; set; }

        [StringLength(100)]
        public string? Image1 { get; set; }

        [StringLength(100)]
        public string? Image2 { get; set; }
    }
}
