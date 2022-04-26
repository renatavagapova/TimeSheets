﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
    /// <summary> Информация о владельце контракта </summary>
    public class Client
    {
        public Guid Id { get; set; }
        public Guid User { get; set; }
        public bool IsDeleted { get; set; }
    }
}
