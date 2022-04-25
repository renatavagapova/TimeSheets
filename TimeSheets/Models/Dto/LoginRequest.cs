using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto
{
    /// <summary> Запрос аутентификации пользователя по логину и паролю </summary>
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
