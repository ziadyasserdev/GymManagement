using GymManagement.BLL.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Features.Plans.Commands.ActivatePlan
{
    public class ActivatePlanCommand : IRequest<Result<string>>
    {
        public int Id { get; set; }
    }
}
