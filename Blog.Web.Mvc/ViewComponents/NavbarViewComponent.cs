using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public NavbarViewComponent() { }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
