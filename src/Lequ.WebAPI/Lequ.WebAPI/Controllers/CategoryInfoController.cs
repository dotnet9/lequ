using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lequ.IService;
using Lequ.Model;
using Lequ.WebAPI.APIResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lequ.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryInfoController : Controller
    {
        private readonly ICategoryInfoService _categoryInfoService;

        public CategoryInfoController(ICategoryInfoService categoryInfoService)
        {
            _categoryInfoService = categoryInfoService;
        }

        [HttpPost]
        public async Task<APIResult.APIResult> Create(string title, string content)
        {
            CategoryInfo category = new CategoryInfo {
                Title = title,
                Content = content
            };
            var oldCategory = await _categoryInfoService.QueryAsync(c => c.Title == title);
            if (oldCategory !=null)
            {
                return APIResultHelper.Error("Exist category");
            }
            bool b = await _categoryInfoService.CreateAsync(category);
            if(b==false)
            {
                return APIResultHelper.Error("Add faile");
            }
            return APIResultHelper.Success(category);
        }
    }
}

