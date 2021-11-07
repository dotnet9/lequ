using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class User : ModelBase
    {
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Account { get; set; }

        [StringLength(20)]
        public string? Password { get; set; }

        [StringLength(50)]
        public string? Title { get; set; }

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(250)]
        public string? About { get; set; }

        [StringLength(100)]
        public string? AboutShort { get; set; }

        [StringLength(50)]
        public string? Address { get; set; }

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        public IEnumerable<Blog>? Blogs { get; set; }
    }
}
