﻿using System.Diagnostics.CodeAnalysis;

namespace HRSystems.DataModel
{
    public class ManagerEmployees
    {
        public int ManagerEmployeeId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public List<int> EmployeeIds { get; set; } = [];
    }
} 

