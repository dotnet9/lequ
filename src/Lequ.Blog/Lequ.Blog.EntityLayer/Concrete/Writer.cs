using System.ComponentModel.DataAnnotations;

namespace Lequ.Blog.EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? About { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Status { get; set; }
    }
}
