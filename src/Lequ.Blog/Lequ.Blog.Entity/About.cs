using System.ComponentModel.DataAnnotations;

namespace Lequ.Blog.Entity
{
    public class About: EntityBase
    {
        public string? Details1 { get; set; }
        public string? Details2 { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? MapLocation { get; set; }
    }
}
