using GymManagement.BLL.Common.Results;
using GymManagement.DAL.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Features.Plans.Commands.ActivatePlan
{
    public class ActivatePlanCommandHandler
    : IRequestHandler<ActivatePlanCommand, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;

        public ActivatePlanCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(
            ActivatePlanCommand request,
            CancellationToken cancellationToken)
        {
            var plan = await unitOfWork.Plans
                .Query()
                .FirstOrDefaultAsync(
                    p => p.Id == request.Id,
                    cancellationToken);

            if (plan is null)
            {
                return Result<string>.Failure(
                    ResultStatus.NotFound,
                    "Plan not found.");
            }

            if (plan.IsActive)
            {
                return Result<string>.Failure(
                    ResultStatus.Conflict,
                    "Plan is already active.");
            }

            plan.IsActive = true;

            unitOfWork.Plans.Update(plan);

            await unitOfWork.SaveAsync();

            return Result<string>.Success(
                $"{plan.Name} activated successfully.");
        }
    }

}
