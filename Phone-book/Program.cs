using System.Collections.Generic;
using Newtonsoft.Json;
using Phone_book.PhoneBookModel;

namespace Phone_book
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var u1 = new User("Петя", new Terminal(new PhoneNumber("222-333-444")));
            var numbers = new Dictionary<PhoneNumberType, PhoneNumber>
            {
                {PhoneNumberType.Work, new PhoneNumber("222-555-666")},
                {PhoneNumberType.Home, new PhoneNumber("333-555-666")}
            };

            u1.AddNewContact(new Contact("Вася", "", numbers));
            var json = JsonConvert.SerializeObject(u1);
            var m = JsonConvert.DeserializeObject<User>(json);
        }
    }
}