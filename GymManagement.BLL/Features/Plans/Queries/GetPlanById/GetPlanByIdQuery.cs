using GymManagement.BLL.Common.Results;
using GymManagement.BLL.Features.Plans.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Features.Plans.Queries.GetPlanById
{
    public class GetPlanByIdQuery : IRequest<Result<PlanViewModel>>
    {
        public int Id { get; set; }
        public GetPlanByIdQuery(int id)
        {
            Id = id;
        }
    }
}
