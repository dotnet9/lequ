using System;
namespace Lequ.WebAPI.APIResult
{
    public class APIResultHelper
    {
        //成功后返回的数据
        public static APIResult Success(dynamic data)
        {
            return new APIResult
            {
                Code = 200,
                Data = data,
                Msg = "Success",
                Total = 0
            };
        }
        public static APIResult Success(dynamic data, int total)
        {
            return new APIResult
            {
                Code = 200,
                Data = data,
                Msg = "Success",
                Total = total
            };
        }
        public static APIResult Error(string msg)
        {
            return new APIResult
            {
                Code = 500,
                Data = null,
                Msg = msg,
                Total = 0
            };
        }
    }
}

