using System.ComponentModel.DataAnnotations;

namespace Lequ.Blog.Model
{
    public class UserInfo : EntityBase
    {
        public string? Name { get; set; }
		public string? Account { get; set; }
		public string? About { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
