using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.ViewComponents
{
	public class _BlogListHeadComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
