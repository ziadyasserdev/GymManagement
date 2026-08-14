using GymManagement.BLL.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Features.Plans.Commands.EditPlan
{
    public class EditPlanCommand : IRequest<Result<string>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DurationDays { get; set; }

        public decimal Price { get; set; }
    }
}
