using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lequ.Blog.Model.Models
{
    public class Comment : ModelBase
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int BlogID { get; set; }
        public Blog? Blog { get; set; }
        public int? ParentID { get; set; }
        public Comment? Parent { get; set; }
	}
}
