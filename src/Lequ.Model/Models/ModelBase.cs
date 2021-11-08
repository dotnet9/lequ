using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lequ.Model.Models
{
	public class ModelBase
	{
		public int ID { get; set; }

		[Obsolete]
		public int Status { get; set; }

		[NotMapped]
		public ModelStatus? StatusEnum
		{
			get
			{
				return (ModelStatus?)Enum.Parse(typeof(ModelStatus), Status.ToString());
			}
			set
			{
				if (value.HasValue)
				{
					this.Status = (int)value.Value;
				}
				else
				{
					this.Status = (int)ModelStatus.Check;
				}
			}
		} 

		public int? CreateUserID { get; set; }

		[NotMapped]
		public User? CreateUser { get; set; }

		public DateTime? CreateDate { get; set; }

		public int? UpdateUserID { get; set; }

		[NotMapped]
		public User? UpdateUser { get; set; }

		public DateTime? UpdateDate { get; set; }
	}
}
