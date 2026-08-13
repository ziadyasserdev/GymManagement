using GymManagement.BLL.Features.Plans.Queries.GetAllPlans;
using GymManagement.BLL.Features.Plans.Queries.GetPlanById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GymManagement.PL.Controllers
{
    public class PlanController : Controller
    {
        private readonly IMediator mediator;

        public PlanController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var result = await mediator.Send(new GetAllPlansQuery());
            return View(result.Value);
        }
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var result = await mediator.Send(new GetPlanByIdQuery(id));
            return View(result.Value);
        }
    }
}
