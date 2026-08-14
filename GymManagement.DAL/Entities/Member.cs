using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Entities
{
    public class Member : GymUser
    {
        public string Photo { get; set; } = default!;
        public HealthRecord HealthRecord { get; set; } = default!;
        public ICollection<Booking> MemberSessions { get; set; } = default!;

        public ICollection<Membership> MemberPlans { get; set; } = default!;
    }
}
