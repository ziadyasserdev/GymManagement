using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.PL.Controllers
{
    public class PlanController : Controller
    {
        private readonly IMediator mediator;

        public PlanController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
