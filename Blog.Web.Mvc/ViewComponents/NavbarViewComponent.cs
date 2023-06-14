using Blog.Business.Services;
using Blog.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.ViewComponents;

public class NavbarViewComponent : ViewComponent
{
	private readonly CategoryService _cs;
	private readonly PageService _pageService;

	public NavbarViewComponent(CategoryService cs, PageService pageService)
	{
		_cs = cs;
		_pageService = pageService;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{

		return View(
			new NavbarDto
			{
				categories = _cs.GetAll(),
				pages = _pageService.GetAll()
			}
			);
	}
}
