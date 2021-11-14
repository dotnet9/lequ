using AutoMapper;
using Lequ.GlobalVar;
using Lequ.IService;
using Lequ.Models;
using Lequ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Lequ.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkService _service;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<LinkController> _localizer;

        public LinkController(ILinkService service, IMapper mapper, IStringLocalizer<LinkController> localizer)
        {
            _service = service;
            _mapper = mapper;
            _localizer = localizer;
        }
        [Authorize]
        public async Task<IActionResult> AdminLinkList()
        {
            var allLinks = await _service.SelectAsync();

            return View(allLinks);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var addLinkDto = new CreateLinkViewModel();
            addLinkDto.StatusEnum = ModelStatus.Normal;
            addLinkDto.Statuses = Enum.GetValues<ModelStatus>();
            return await Task.FromResult(View(addLinkDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLinkViewModel addLinkDto)
        {
            if (ModelState.IsValid)
            {
                var linkFromDatabase = _mapper.Map<Link>(addLinkDto);
                linkFromDatabase.CreateDate = DateTime.Now;
                linkFromDatabase.CreateUserID = HttpContext.Session.Get<int>(GlobalVars.SESSION_USER_ID_KEY);
                await _service.InsertAsync(linkFromDatabase);
                return RedirectToAction(nameof(AdminLinkList));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(x => x.ID == id);
            return RedirectToAction(nameof(AdminLinkList));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var linkFromDatabase = await _service.GetAsync(x => x.ID == id);
            if (linkFromDatabase == null)
            {
                return NotFound();
            }
            var editLinkDto = _mapper.Map<UpdateLinkViewModel>(linkFromDatabase);
            editLinkDto.Statuses = Enum.GetValues<ModelStatus>();
            return View(editLinkDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateLinkViewModel editLinkDto)
        {
            if (id != editLinkDto.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var linkFromDatabase = await _service.GetAsync(x => x.ID == editLinkDto.ID);
                if (linkFromDatabase == null) return View();

                _mapper.Map(editLinkDto, linkFromDatabase, typeof(UpdateLinkViewModel), typeof(Link));
                linkFromDatabase.UpdateDate = DateTime.Now;
                linkFromDatabase.UpdateUserID = HttpContext.Session.Get<int>(GlobalVars.SESSION_USER_ID_KEY);

                await _service.UpdateAsync(linkFromDatabase);
                return RedirectToAction(nameof(AdminLinkList));

            }
            return View();
        }
    }
}
