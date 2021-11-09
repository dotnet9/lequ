using AutoMapper;
using Lequ.IService;
using Lequ.Model;
using Lequ.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IContactService _service;

        public ContactController(IContactService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> SendMessage()
        {
            return await Task.FromResult(View());
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Contact contact)
        {
            contact.CreateDate = DateTime.Now;
            contact.UpdateDate = DateTime.Now;
            contact.StatusEnum = ModelStatus.Normal;
            await _service.InsertAsync(contact);
            return RedirectToAction("SendMessage");
        }
    }
}