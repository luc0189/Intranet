﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class UserApp
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
