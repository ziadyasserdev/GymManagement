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

namespace GymManagement.BLL.Features.Plans.Queries.GetAllPlans
{
    public class GetAllPlansQueryHandler : IRequestHandler<GetAllPlansQuery, Result<List<PlanViewModel>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllPlansQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<List<PlanViewModel>>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
        {
           var plans = await unitOfWork.Plans.Query()
                .AsNoTracking()
             .Select(c => new PlanViewModel
             {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    DurationDays = c.DurationDays,
                    IsActive = c.IsActive

             }).ToListAsync(cancellationToken);
            if(plans == null || !plans.Any())
           
                return Result<List<PlanViewModel>>.Failure(ResultStatus.NotFound,"No plans found.");
            return Result<List<PlanViewModel>>.Success(plans);

        }
    }
}
