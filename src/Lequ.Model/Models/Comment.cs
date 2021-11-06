using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Comment : ModelBase
    {
        [StringLength(50)]
        public string? UserName { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? Website { get; set; }

        [StringLength(200)]
        public string? Content { get; set; }

        public int BlogID { get; set; }

        public Blog? Blog { get; set; }

        public int? ParentID { get; set; }

        public Comment? Parent { get; set; }
    }
}
