using System.ComponentModel.DataAnnotations;

namespace Lequ.Models
{
    public class Contact : ModelBase
    {
        [StringLength(50)] public string? Name { get; set; }

        [StringLength(50)] public string? Email { get; set; }

        [StringLength(50)] public string? Subject { get; set; }

        public string? Message { get; set; }
    }
}