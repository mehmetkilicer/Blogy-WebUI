using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.ViewComponents
{
	public class _FooterComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
