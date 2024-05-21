using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.ViewComponents
{
	public class _ScriptComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
