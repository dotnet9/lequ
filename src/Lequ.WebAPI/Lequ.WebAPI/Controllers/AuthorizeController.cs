using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Lequ.IService;
using Lequ.WebAPI.APIResult;
using Lequ.WebAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lequ.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private readonly IUserInfoService _userInfoService;
        public AuthorizeController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpPost("Login")]
        public async Task<APIResult.APIResult> Login(string account, string password)
        {
            string pwd = MD5Helper.MD5Encrypt32(password);
            var users = await _userInfoService.QueryAsync(c => c.Account == account && c.Password == password);
            if (users == null || users.Count() <=0)
            {
                return APIResultHelper.Error("Invalid account or password");
            }
            var user = users.First();
                //登陆成功
                var claims = new Claim[]
                    {
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim("Account", user.Account!),
                    };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VF"));
                //issuer代表颁发Token的Web应用程序，audience是Token的受理者
                var token = new JwtSecurityToken(
                    issuer: "http://localhost:6060",
                    audience: "http://localhost:5000",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return APIResultHelper.Success(jwtToken);
        }
    }
}

