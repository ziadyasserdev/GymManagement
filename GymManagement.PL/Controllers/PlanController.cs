using Microsoft.AspNetCore.Mvc;

namespace GymManagement.PL.Controllers
{
    public class PlanController : Controller
    {
        public PlanController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
