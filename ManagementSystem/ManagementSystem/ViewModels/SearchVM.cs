using ManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace ManagementSystem.ViewModels
{
    public class SearchVM
    {

        public DateTime? EndTime { get; set; }
        public DateTime? StartTime { get; set; }
        public List<Models.Table> Tables { get; set; } = new List<Models.Table>();
    }
}
