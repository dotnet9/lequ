using Lequ.Models;

namespace Lequ.ViewModels
{
    public class CommentDto : DtoBase
    {
        public int Floor { get; set; }

        public int BlogID { get; set; }

        public Blog? Blog { get; set; }

        public int? ParentID { get; set; }

        public CommentDto? Parent { get; set; }

        public string? Content { get; set; }
    }
}