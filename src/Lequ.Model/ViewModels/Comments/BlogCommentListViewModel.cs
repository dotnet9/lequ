using Lequ.Model.Models;

namespace Lequ.Model.ViewModels.Comments
{
    public class BlogCommentListViewModel
    {
        public int BlogID { get; set; }
        public List<CommentDto>? Comments { get; set; }
    }
}
