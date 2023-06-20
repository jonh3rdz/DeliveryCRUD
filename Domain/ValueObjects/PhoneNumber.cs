using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public partial record PhoneNumber
{
    private const int DefaultLenght = 9;
    private const string Pattern = @"^(?:-*\d-*){8}$";

    private PhoneNumber(string value) => Value = value;

    public static PhoneNumber? Create(string value)
    {
        if (string.IsNullOrEmpty(value) || !PhoneNumberRegex().IsMatch(value) || value.Length != DefaultLenght)
        {
            return null;
        }

        return new PhoneNumber(value);
    }

    // public static PhoneNumber? Update(PhoneNumber phoneNumber, string value)
    // {
    //     if (phoneNumber is null || string.IsNullOrEmpty(value) || !PhoneNumberRegex().IsMatch(value) || value.Length != DefaultLenght)
    //     {
    //         return null;
    //     }

    //     return new PhoneNumber(value);
    // }

    public static List<PhoneNumber> GetAll()
    {
        return new List<PhoneNumber>();
    }

    public static PhoneNumber? GetById(Guid id)
    {
        return null;
    }

    public static bool Delete(Guid id)
    {
        return true;
    }

    public bool Update()
    {
        return true;
    }

    public string Value { get; init; }

    [GeneratedRegex(Pattern)]
    private static partial Regex PhoneNumberRegex();
}