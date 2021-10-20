using System;
namespace Lequ.WebAPI.APIResult
{
    public class APIResult
    {
        public int Code { get; set; }
        public string? Msg { get; set; }
        public int Total { get; set; }
        public dynamic? Data { get; set; }
    }
}

