using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace SignalRWebUi.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
