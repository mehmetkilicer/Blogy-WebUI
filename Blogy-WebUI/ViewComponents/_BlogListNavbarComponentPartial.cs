using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.ViewComponents
{
	public class _BlogListNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
