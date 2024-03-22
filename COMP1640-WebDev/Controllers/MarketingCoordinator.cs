using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640_WebDev.Controllers
{

/*    [Authorize(Roles = "Marketing Coordinator")]
*/    public class MarketingCoordinator : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PostsManagement()
        {
            return View();
        }
    }
}
