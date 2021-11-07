using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class About : ModelBase
    {
        [StringLength(500)]
        public string? Details1 { get; set; }

        [StringLength(500)]
        public string? Details2 { get; set; }

        [StringLength(200)]
        public string? Image1 { get; set; }

        [StringLength(200)]
        public string? Image2 { get; set; }
    }
}
