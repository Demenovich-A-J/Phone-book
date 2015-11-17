using System.Collections.Generic;

namespace Phone_book
{
    public interface IContact
    {
        string Name { get; }
        string SurName { get; }
        IDictionary<PhoneNumberType,PhoneNumber> Numbers { get; } 
    }
}