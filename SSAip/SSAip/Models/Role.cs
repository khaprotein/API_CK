﻿using System;
using System.Collections.Generic;

namespace SSAip.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string RoleId { get; set; } = null!;
        public string? RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
