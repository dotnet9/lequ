using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lequ.Models
{
    public class User : ModelBase
    {
        [StringLength(50)] public string? Name { get; set; }

        [StringLength(50)] public string? Account { get; set; }

        [StringLength(20)] public string? Password { get; set; }

        [StringLength(50)] public string? Title { get; set; }

        [StringLength(200)] public string? Image { get; set; }

        [StringLength(250)] public string? About { get; set; }

        [StringLength(100)] public string? AboutShort { get; set; }

        [StringLength(50)] public string? Address { get; set; }

        [StringLength(20)] public string? PhoneNumber { get; set; }

        [StringLength(100)] public string? Email { get; set; }

        [Obsolete] public int Role { get; set; }

        [NotMapped]
        public UserRoleEnum? RoleEnum
        {
            get => (UserRoleEnum?)Enum.Parse(typeof(UserRoleEnum), Role.ToString());
            set
            {
                if (value.HasValue)
                    Role = (int)value.Value;
                else
                    Role = (int)UserRoleEnum.User;
            }
        }

        public IEnumerable<Blog>? Blogs { get; set; }
    }

    public enum UserRoleEnum { Admin, Author, User}

    public class UserRole
    {
        public const string Admin = "Admin";
        public const string Author ="Author";
        public const string User = "User";
    }
}