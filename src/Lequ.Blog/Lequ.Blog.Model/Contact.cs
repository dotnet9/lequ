using System.ComponentModel.DataAnnotations;

namespace Lequ.Blog.Model
{
    public class Contact : EntityBase
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
