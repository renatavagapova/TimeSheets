﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
    /// <summary> Refresh Token пользователей </summary>
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
