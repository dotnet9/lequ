using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers;

public class TagController : Controller
{
	private readonly ITagService _tagService;

	public TagController(ITagService tagService)
	{
		_tagService = tagService;
	}

	public IActionResult Index()
	{
		return View();
	}
}