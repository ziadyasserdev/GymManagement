using GymManagement.BLL.Common.Results;
using GymManagement.BLL.Features.Plans.ViewModels;
using GymManagement.DAL.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Features.Plans.Queries.GetPlanById
{
    public class GetPlanByIdQueryHandler : IRequestHandler<GetPlanByIdQuery, Result<PlanViewModel>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetPlanByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<PlanViewModel>> Handle(GetPlanByIdQuery request, CancellationToken cancellationToken)
        {
            var plan = await unitOfWork.Plans.Query()
                 .Where(c => c.Id == request.Id)
                 .Select(c => new PlanViewModel
                 {
                     Id = c.Id,
                     Name = c.Name,
                     Description = c.Description,
                     Price = c.Price,
                     DurationDays = c.DurationDays,
                     IsActive = c.IsActive

                 }).FirstOrDefaultAsync(cancellationToken);
            if(plan is null)
            return Result<PlanViewModel>.Failure(ResultStatus.NotFound,"Plan not found");
            return Result<PlanViewModel>.Success(plan);
        }
    }
}
