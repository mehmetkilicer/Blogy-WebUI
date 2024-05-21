using Microsoft.AspNetCore.Mvc;

namespace Blogy_WebUI.Areas.Writer.ViewComponents.LayoutViewComponents
{
    public class _LayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
