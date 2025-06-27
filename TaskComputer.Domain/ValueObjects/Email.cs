using System.Text.RegularExpressions;

namespace TaskComputer.Domain.ValueObjects
{
    public partial record Email
    {
        public string Value {get ; init; }
        private Email(string value) => Value = value;
        private const string Pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();

        public static Email? Create(string value)
        {
            if (!EmailRegex().IsMatch(value)) return null;
            return new Email(value);
        }
    }
}
