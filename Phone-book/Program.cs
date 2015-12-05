using System;
using System.Collections.Generic;
using Phone_book.DAL.Repositoys;
using static System.Console;

namespace Phone_book
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var userRepository = new UserRepository();
            var contactRepository = new ContactsRepository();
            var phonesRepository = new PhonesRepository();

            WriteLine("Input your name : ");
            var userName = ReadLine();

            var user = userRepository.GetSingle(x => x.Name == userName);

            if (user == null)
            {
                userRepository.Add(new User {Name = userName});
                user = userRepository.GetSingle(x => x.Name == userName);
            }

            do
            {
                WriteLine("Input Comand : ");
                var comand = ReadLine();
                switch (comand)
                {
                    case "Add":
                        WriteLine("Input Name");
                        var name = ReadLine();
                        WriteLine("Input Surname");
                        var surName = ReadLine();
                        var phones = new List<Phones>();
                        do
                        {
                            WriteLine("Input Number");
                            var number = ReadLine();
                            WriteLine("Input Type");
                            var type = ReadLine();
                            phones.Add(new Phones
                            {
                                Number = number,
                                Type = type
                            });
                        } while (ReadKey().Key != ConsoleKey.Backspace);

                        contactRepository.Add(new Contacts
                        {
                            UserId = user.Id,
                            Name = name,
                            Surname = surName,
                            Phones = phones
                        });

                        break;
                    case "Show":
                        foreach (var contact in contactRepository.GetList(x => x.UserId == user.Id))
                        {
                            WriteLine($"Name {contact.Name}; Surname {contact.Surname}; Numbers : ");
                            foreach (var phone in phonesRepository.GetList(x => x.ContactId == contact.Id))
                            {
                                WriteLine($"Number: {phone.Number}; Type: {phone.Type}");
                            }
                        }
                        break;
                    case "Edit":
                        WriteLine("Input Name of contact");
                        var resName = ReadLine();
                        var rescontact = contactRepository.GetSingle(x => x.Name == resName);

                        WriteLine("Input Field name to edit");
                        var editComand = ReadLine();

                        switch (editComand)
                        {
                            case "Name":
                                WriteLine("Input new Name");
                                rescontact.Name = ReadLine();
                                contactRepository.Update(rescontact);
                                break;
                            case "Surname":
                                WriteLine("Input new Surname");
                                rescontact.Surname = ReadLine();
                                contactRepository.Update(rescontact);
                                break;
                            case "Number":
                                WriteLine("Input Number");
                                var resNumber = ReadLine();
                                var phone = phonesRepository.GetSingle(x => x.Number == resNumber);
                                WriteLine("Input new Number");
                                phone.Number = ReadLine();
                                WriteLine("Input Type");
                                phone.Type = ReadLine();
                                phonesRepository.Update(phone);
                                break;
                            case "AddNumber":
                                var resphones = new List<Phones>();
                                do
                                {
                                    WriteLine("Input Number");
                                    var number = ReadLine();
                                    WriteLine("Input Type");
                                    var type = ReadLine();
                                    resphones.Add(new Phones
                                    {
                                        Number = number,
                                        Type = type
                                    });
                                    WriteLine("Press backspace to end.");
                                } while (ReadKey().Key != ConsoleKey.Backspace);
                                foreach (var ph in resphones)
                                {
                                    phonesRepository.Add(ph);
                                }
                                break;
                        }
                        break;
                    case "Remove":
                        WriteLine("Input name");
                        var remName = ReadLine();
                        WriteLine("Input surname");
                        var remSurname = ReadLine();
                        contactRepository.Remove(
                            contactRepository.GetSingle(x => x.Name == remName && x.Surname == remSurname));
                        break;
                }
                WriteLine("Press backspace to exit.");
            } while (ReadKey().Key != ConsoleKey.Backspace);
        }
    }
}