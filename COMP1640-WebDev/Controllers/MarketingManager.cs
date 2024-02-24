using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640_WebDev.Controllers
{
    [Authorize(Roles = "Marketing Manager")]
    public class MarketingManager : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
