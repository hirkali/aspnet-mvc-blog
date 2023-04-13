using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.Controllers
{
	
	public class BlogController : Controller
	{
		[Route("~/blog/{query}-{page}")]
		public IActionResult Search(string query, int page)
		{
			return View();
		}
		[Route("~/blog/{id}")]
		public IActionResult Detail(int id)
		{
			return View();
		}
	}
}
