using System.ComponentModel.DataAnnotations;

namespace Lequ.Blog.Model.Models
{
    public class Contact : ModelBase
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
