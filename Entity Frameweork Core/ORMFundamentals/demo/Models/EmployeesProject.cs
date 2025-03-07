﻿using System;
using System.Collections.Generic;

#nullable disable

namespace demo.Models
{
    public partial class EmployeesProject
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
