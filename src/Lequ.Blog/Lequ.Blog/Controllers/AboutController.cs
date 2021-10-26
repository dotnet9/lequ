﻿using AutoMapper;
using Lequ.Blog.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _service;
        private readonly IMapper _mapper;

        public AboutController(IAboutService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var about = await _service.GetAllAsync();
            return View(about);
        }

        public async Task<PartialViewResult> SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
