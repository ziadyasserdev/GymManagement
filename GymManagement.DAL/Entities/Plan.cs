using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Entities
{
    public class Plan : BaseEntity
    {
        public string Name = string.Empty;
        public string Description = string.Empty;
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

    }
}
