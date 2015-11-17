using System.Collections.Generic;

namespace Phone_book
{
    public class Contact : IContact
    {
        public Contact(string name, string surName, IDictionary<PhoneNumberType, PhoneNumber> numbers)
        {
            Name = name;
            SurName = surName;
            Numbers = numbers;
        }

        public string Name { get; }
        public string SurName { get; }
        public IDictionary<PhoneNumberType, PhoneNumber> Numbers { get; }

        public void AddNumber(PhoneNumberType type, PhoneNumber number)
        {
            Numbers.Add(type,number);
        }
    }
}