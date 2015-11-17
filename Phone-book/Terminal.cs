using System.Collections.Generic;
using Phone_book.PhoneBookModel;

namespace Phone_book
{
    public class Terminal
    {
        public Terminal(PhoneNumber number)
        {
            Number = number;
            Contacts = new List<Contact>();
        }

        public PhoneNumber Number { get; }
        public ICollection<Contact> Contacts { get; }

        public void Add(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void Remove(Contact contact)
        {
            Contacts.Remove(contact);
        }
    }
}