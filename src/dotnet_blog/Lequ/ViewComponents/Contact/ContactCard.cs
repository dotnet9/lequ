using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Contact
{
	public class ContactCard : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IContactService _service;

        public ContactCard(IContactService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}