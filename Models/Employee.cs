using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class Employee
    {
        public string EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public string EmployeeName { get; set; }
        public decimal? CostHour { get; set; }
        public decimal? HoursDay { get; set; }

        public virtual Company Company { get; set; }
    }
}
