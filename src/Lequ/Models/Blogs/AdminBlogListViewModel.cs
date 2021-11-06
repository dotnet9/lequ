using Lequ.Model.Models;

namespace Lequ.Models.Blogs
{
    public class AdminBlogListViewModel
    {
        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        public List<Blog>? Blogs { get; set; }
    }
}
