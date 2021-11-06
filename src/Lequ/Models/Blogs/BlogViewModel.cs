using Lequ.Model;

namespace Lequ.Models.Blogs
{
    public class BlogViewModel : ViewModelBase
    {
        public string? Title { get; set; }

        public string? Image { get; set; }

        public string? Content { get; set; }

        public List<BlogCategory>? BlogCategories { get; set; }

        public List<BlogTag>? BlogTags { get; set; }

        public List<BlogAlbum>? BlogAlbums { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
