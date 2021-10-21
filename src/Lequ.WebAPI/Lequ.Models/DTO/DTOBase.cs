using System;
namespace Lequ.Models.DTO
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

