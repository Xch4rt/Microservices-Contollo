namespace UserService.Domain.ValueObjects
{
    public class Email
    {
        public string Value {get; private set;}

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value) || !value.Contains("@"))
            {
                throw new ArgumentException("Invalid email address");
            }

            Value = value;
        }
    }
}
