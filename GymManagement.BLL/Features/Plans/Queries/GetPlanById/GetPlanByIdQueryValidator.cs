using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Features.Plans.Queries.GetPlanById
{
    public class GetPlanByIdQueryValidator
       : AbstractValidator<GetPlanByIdQuery>
    {
        public GetPlanByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Plan ID must be greater than 0.");
        }
    }
}
