using GymManagement.BLL.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Features.Plans.Commands.AddPlan
{
  public record AddPlanCommand(string Name,string Description,int DurationDays,decimal Price) 
        : IRequest<Result<string>>
    { }
  
}
