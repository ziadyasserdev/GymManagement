using GymManagement.BLL.Common.Results;
using GymManagement.BLL.Features.Plans.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Features.Plans.Queries.GetAllPlans
{
    public class GetAllPlansQuery : IRequest<Result<List<PlanViewModel>>>
    {
    }
}
