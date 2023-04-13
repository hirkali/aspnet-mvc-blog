using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.Controllers
{
	public class PageController : Controller
	{
        [Route("~/page/{id}")]
        public IActionResult Detail(int id)
		{
			return View();
		}
	}
}
