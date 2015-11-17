using Phone_book.PhoneBookModel;

namespace Phone_book
{
    public class User
    {
        public User(string name, Terminal terminal)
        {
            Name = name;
            Terminal = terminal;
        }

        public string Name { get; }

        public Terminal Terminal { get; }

        public void AddNewContact(Contact contact)
        {
            Terminal.Add(contact);
        }
    }
}