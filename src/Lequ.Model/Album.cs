using System.ComponentModel.DataAnnotations;

namespace Lequ.Model
{
    public class Album : ModelBase
    {
        [StringLength(30)]
        public string? Name { get; set; }


        [StringLength(500)]
        public string? Description { get; set; }


        public List<BlogAlbum>? BlogAlbums { get; set; }
    }
}
