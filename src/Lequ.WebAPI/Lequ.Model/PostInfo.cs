using System;
using System.ComponentModel.DataAnnotations;

namespace Lequ.Model
{
    public class PostInfo : EntityBase
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public CategoryInfo? Category { get; set; }
        public int ReadCount { get; set; }
        public int LikeCount { get; set; }
    }
}

