using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lequ.Model
{
    public class EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public long CreateTime { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        public UserInfo? CreateUser { get; set; }
        public long? UpdateTime { get; set; }
        public int? UpdateUserID { get; set; }
        public UserInfo? UpdateUser { get; set; }
    }
}

