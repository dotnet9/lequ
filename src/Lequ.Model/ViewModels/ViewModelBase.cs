using Lequ.Model.Models;

namespace Lequ.Model.ViewModels
{
    public class ViewModelBase
	{
        public int ID { get; set; }

        public ModelStatus? Status { get; set; } = ModelStatus.Disable;

        public int? CreateUserID { get; set; }

        public User? CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? UpdateUserID { get; set; }

        public User? UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public ModelStatus[]? Statuses { get; set; }
    }
}
