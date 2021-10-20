using System;
namespace Lequ.Model.DTO
{
    public class DTOBase
    {
        public int ID { get; set; }
        public long CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public long? UpdateTime { get; set; }
        public int? UpdateUserID { get; set; }
    }
}

