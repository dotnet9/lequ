using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;
        private readonly IMapper _mapper;

        public ContactController(IContactService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(Contact contact)
        {
            contact.Status = true;
            contact.CreateDate= DateTime.Now;
            await _service.AddAsync(contact);
            return RedirectToAction("Index", "Blog");
        }
    }
}
