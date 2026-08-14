using GymManagement.BLL.Features.Plans.Commands.ActivatePlan;
using GymManagement.BLL.Features.Plans.Commands.AddPlan;
using GymManagement.BLL.Features.Plans.Commands.DeactivePlan;
using GymManagement.BLL.Features.Plans.Commands.EditPlan;
using GymManagement.BLL.Features.Plans.Queries.GetAllPlans;
using GymManagement.BLL.Features.Plans.Queries.GetPlanById;
using GymManagement.DAL.Entities;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddPlanCommand command)
        {
            var validator = new AddPlanCommandValidator();

            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(
                        error.PropertyName,
                        error.ErrorMessage);
                }

                return View(command);
            }

            var result = await mediator.Send(command);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(
                    string.Empty,
                    result.Message);

                return View(command);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await mediator.Send(
                new GetPlanByIdQuery(id));

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            var plan = result.Value;

            var command = new EditPlanCommand
            {
                Id = plan.Id,
                Name = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price
            };

            return View(command);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditPlanCommand command)
        {
            var validator = new EditPlanCommandValidator();

            var validationResult =
                await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(
                        error.PropertyName,
                        error.ErrorMessage);
                }

                return View(command);
            }

            var result = await mediator.Send(command);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(
                    string.Empty,
                    result.Message);

                return View(command);
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Deactivate(int id)
        {
            var result = await mediator.Send(
                new DeactivePlanCommand { Id = id });

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = result.Message;

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Activate(int id)
        {
            var result = await mediator.Send(
                new ActivatePlanCommand { Id = id });

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = result.Message;

            return RedirectToAction(nameof(Index));
        }
    }
}
