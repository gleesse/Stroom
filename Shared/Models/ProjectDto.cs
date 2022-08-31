﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroom.Shared.Models
{
    public class ProjectDto
    {
        public int ProjectID { get; set; } = 1303;
        public string Name { get; set; } = "Moon colony";
        public string Description { get; set; } = "Moon colony development";
        public virtual List<User> AssignedUsers { get; set; } = new List<User>();
        public virtual List<TaskDto> Tasks { get; set; } = new List<TaskDto>();

        public override bool Equals(object o)
        {
            var other = o as ProjectDto;
            return other?.Name == Name;
        }

        public override int GetHashCode() => Name?.GetHashCode() ?? 0;

        public override string ToString() => Name;
    }
}
