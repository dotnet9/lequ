using System.ComponentModel.DataAnnotations.Schema;
using Lequ.Models;

namespace Lequ.ViewModels
{
    public class DtoBase
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

        public User? CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? UpdateUserID { get; set; }

        public User? UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public ModelStatus[]? Statuses { get; set; }
    }
}