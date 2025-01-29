namespace Domain.ValueObjects;

public class PhoneNumber
{
    public string Type { get; private set; }
    public string Number { get; private set; }

    public PhoneNumber(string type, string number)
    {
        ValidateType(type);
        ValidateNumber(number);
        Type = type;
        Number = number;
    }

    private void ValidateType(string type)
    {
        if (type != "mobile" && type != "office" && type != "home")
            throw new ArgumentException("Phone type must be 'mobile', 'office', or 'home'.");
    }

    private void ValidateNumber(string number)
    {
        if (number.Length < 4 || number.Length > 50)
            throw new ArgumentException("Phone number must be between 4 and 50 characters.");
    }
}