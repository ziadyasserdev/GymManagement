using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Features.Plans.Commands.AddPlan
{
    public class AddPlanCommandValidator : AbstractValidator<AddPlanCommand>
    {
        public AddPlanCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull().WithMessage("Name cannot be null.");

            RuleFor(d => d.Description)
                .NotEmpty().WithMessage("Description is required.")
                .NotNull().WithMessage("Description cannot be null.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .MinimumLength(10).WithMessage("Description must be at least 10 characters long.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(d => d.DurationDays)
                .GreaterThan(0).WithMessage("Duration must be greater than 0 days.");
        }
    }
}
