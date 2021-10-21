using System;
using System.ComponentModel.DataAnnotations;

namespace Lequ.Models
{
    public class UserInfo : EntityBase
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Memo { get; set; }
        [Required]
        public string? Account { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}

