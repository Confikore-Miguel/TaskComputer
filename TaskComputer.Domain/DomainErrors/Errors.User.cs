using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskComputer.Domain.DomainErrors
{
    public static class Errors
    {
        public static class User
        {
            public static Error EmailNotValid=> Error.Validation(
                "User.Email",
                "Email is not valid."
            );
        }
    }
}
