﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto
{
    /// <summary> Информация о роли пользователя </summary>
    public class UserRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
