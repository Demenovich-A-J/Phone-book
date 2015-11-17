using System.Collections.Generic;

namespace Phone_book
{
    public class Terminal : ITerminal
    {
        public Terminal(PhoneNumber number)
        {
            Number = number;
            Contacts = new List<IContact>();
        }

        public PhoneNumber Number { get; }
        public ICollection<IContact> Contacts { get; }

        public void Add(IContact contact)
        {
            Contacts.Add(contact);
        }

        public void Remove(IContact contact)
        {
            Contacts.Remove(contact);
        }
    }
}