using Lequ.Model.Models;

namespace Lequ.Model.ViewModels.Comments
{
    public class CommentDto : ViewModelBase
    {
        public int Floor { get; set; }

        public int BlogID { get; set; }

        public Blog? Blog { get; set; }

        public int? ParentID { get; set; }

        public CommentDto? Parent { get; set; }

        public string? Content { get; set; }
    }
}