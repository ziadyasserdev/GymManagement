using GymManagement.BLL.Common.Results;
using GymManagement.DAL.Entities;
using GymManagement.DAL.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Features.Plans.Commands.AddPlan
{
    public class AddPlanCommandHandler : IRequestHandler<AddPlanCommand, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;

        public AddPlanCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<string>> Handle(AddPlanCommand request, CancellationToken cancellationToken)
        {
            var checkExist = await unitOfWork.Plans.Query()
                .AnyAsync(p => p.Name == request.Name && p.IsActive
                , cancellationToken);

            if(checkExist)
                return Result<string>.Failure(ResultStatus.Conflict, "Plan with the same name already exists.");
            var plan = new Plan
            {
                Name = request.Name,
                Description = request.Description,
                DurationDays = request.DurationDays,
                CreatedAt = DateTime.Now,
                Price = request.Price,
                IsActive = true

            };
            await unitOfWork.Plans.AddAsync(plan);
            await unitOfWork.SaveAsync();
            return Result<string>.Success($"{plan.Name} add successfully");
        }
    }
}
