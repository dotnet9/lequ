using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Admin : ModelBase
    {
        [StringLength(20)]
        public string? UserName { get; set; }
        [StringLength(20)]
        public string? Password { get; set; }
    }
}
