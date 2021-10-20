using System;
using System.ComponentModel.DataAnnotations;

namespace Lequ.Model
{
    public class CategoryInfo : EntityBase
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
    }
}

