using AutoMapper;
using Lequ.IService;
using Lequ.Models;
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
			contact.StatusEnum = ModelStatus.Normal;
			await _service.InsertAsync(contact);
			return RedirectToAction("SendMessage");
		}

		public async Task<IActionResult> SendBox()
		{
			var messageList = await _service.SelectAsync(x => x.ID > 0, x => x.CreateDate, SortDirection.Descending);
			return View(messageList);
		}

		public async Task<IActionResult> Details(int id = 1)
		{
			var message = await _service.GetAsync(x => x.ID == id);
			return View(message);
		}
	}
}