using System.ComponentModel.DataAnnotations;

namespace Lequ.Model.Models
{
    public class Album : ModelBase
    {
        [StringLength(30)]
        public string? Name { get; set; }

        public List<BlogAlbum>? BlogAlbums { get; set; }
    }
}
