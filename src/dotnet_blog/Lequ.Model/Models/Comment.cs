using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Comment : ModelBase
    {
        public int BlogID { get; set; }

        public Blog? Blog { get; set; }

        public int? ParentID { get; set; }

        public Comment? Parent { get; set; }

        [StringLength(200)] public string? Content { get; set; }
    }
}