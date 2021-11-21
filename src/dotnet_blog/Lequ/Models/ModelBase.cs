using System.ComponentModel.DataAnnotations.Schema;

namespace Lequ.Models
{
    public class ModelBase
    {
        public int ID { get; set; }

        // Used for EF Core
        public int Status { get; set; }

        // Used for code
        [NotMapped]
        public ModelStatus? StatusEnum
        {
            get => (ModelStatus?)Enum.Parse(typeof(ModelStatus), Status.ToString());
            set
            {
                if (value.HasValue)
                    Status = (int)value.Value;
                else
                    Status = (int)ModelStatus.Check;
            }
        }

        public int? CreateUserID { get; set; }

        [NotMapped] public User? CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? UpdateUserID { get; set; }

        [NotMapped] public User? UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}