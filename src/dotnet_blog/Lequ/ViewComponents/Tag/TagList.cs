using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Tag;

public class TagList : ViewComponent
{
    private readonly IMapper _mapper;
    private readonly ITagService _service;

    public TagList(ITagService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var value = await _service.SelectAsync(x => x.BlogTags!);
        return View((from p in value orderby p.BlogTags?.Count descending select p).ToList());
    }
}