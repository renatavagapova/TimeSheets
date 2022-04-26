using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Infrastructure.Validation
{
    public static class ValidationMessages
    {
        public const string SheetAmountError = "Amount should by between 1 and 8 hours.";
        public const string CannotBeEmpty = "The field cannot be empty.";
        public const string InvalidValue = "Incorrect Value";
        public const string InvalidAddress = "Invalid Email address";
    }
}
