using System.ComponentModel.DataAnnotations;

namespace Lequ.Blog.Model.Models
{
    public class About: ModelBase
    {
        public string? Details1 { get; set; }
        public string? Details2 { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? MapLocation { get; set; }
    }
}
