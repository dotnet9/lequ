using System.ComponentModel.DataAnnotations.Schema;
using Lequ.Models;

namespace Lequ.ViewModels
{
    public class ViewModelBase
    {
        public int ID { get; set; }

        [Obsolete] public int Status { get; set; }

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

        public string CreateDateString { get { return CreateDate == null ? "-" : CreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"); } }

        public int? UpdateUserID { get; set; }

        public User? UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateDateString { get { return UpdateDate == null ? "-" : UpdateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"); } }

        public ModelStatus[]? Statuses { get; set; }
    }
}