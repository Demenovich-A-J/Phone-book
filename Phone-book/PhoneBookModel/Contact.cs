using System.Collections.Generic;

namespace Phone_book.PhoneBookModel
{
    public class Contact
    {
        public Contact(string name, string surName, Dictionary<PhoneNumberType, PhoneNumber> numbers)
        {
            Name = name;
            SurName = surName;
            Numbers = numbers;
        }

        public string Name { get; }
        public string SurName { get; }
        public Dictionary<PhoneNumberType, PhoneNumber> Numbers { get; }

        public void AddNumber(PhoneNumberType type, PhoneNumber number)
        {
            Numbers.Add(type, number);
        }
    }
}