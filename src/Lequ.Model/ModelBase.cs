using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lequ.Model
{
    public class ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public ModelStatus? Status { get; set; } = ModelStatus.Disable;

        public int? CreateUserID { get; set; }

        [NotMapped]
        public User? CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? UpdateUserID { get; set; }

        [NotMapped]
        public User? UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }

    public enum ModelStatus
    {
        IsDeleted, Normal, Disable, Check
    }
    public enum SortDirection
    {
        Ascending, Descending
    }
}
