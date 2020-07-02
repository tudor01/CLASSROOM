﻿using ClassroomPlatform.ApplicationLogic.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomPlatform.VIewModels.Administrator
{
    public class AdministratorViewModel
    {
        public IEnumerable<IdentityUser> Users { get; set; }
    }
}
