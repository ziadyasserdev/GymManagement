using GymManagement.BLL.Common.Results;
using GymManagement.DAL.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Features.Plans.Commands.EditPlan
{
    public class EditPlanCommandHandler
      : IRequestHandler<EditPlanCommand, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;

        public EditPlanCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(
            EditPlanCommand request,
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

            var checkExist = await unitOfWork.Plans
                .Query()
                .AnyAsync(
                    p => p.Id != request.Id &&
                         p.Name == request.Name &&
                         p.IsActive,
                    cancellationToken);

            if (checkExist)
            {
                return Result<string>.Failure(
                    ResultStatus.Conflict,
                    "Plan with the same name already exists.");
            }

            plan.Name = request.Name;
            plan.Description = request.Description;
            plan.DurationDays = request.DurationDays;
            plan.Price = request.Price;

            unitOfWork.Plans.Update(plan);

            await unitOfWork.SaveAsync();

            return Result<string>.Success(
                $"{plan.Name} updated successfully");
        }
    }
}
