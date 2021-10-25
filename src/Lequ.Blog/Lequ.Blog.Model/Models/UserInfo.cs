using System.ComponentModel.DataAnnotations;

namespace Lequ.Blog.Model.Models
{
    public class UserInfo : ModelBase
    {
        public string? Name { get; set; }
		public string? Account { get; set; }
		public string? About { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
