using System;
using System.Collections.Generic;
using Phone_book.DAL.Repositoys;
using Phone_book.DAL.Repositoys.Intarfaces;
using static System.Console;


namespace Phone_book.Configurators
{
    public class ComandsConfig
    {
        private static IGenericDataRepository<DAL.Models.Users> _userRepository = new UserRepository();

        private static IGenericDataRepository<DAL.Models.Contactss> _contactRepository = new ContactsRepository();

        private static IGenericDataRepository<DAL.Models.Phoness> _phonesRepository = new PhonesRepository();
        private static DAL.Models.Users _users;

        public ComandsConfig()
        {
            WriteLine("Input your name : ");
            var userName = ReadLine();

            _users = new DAL.Models.Users { Name = userName };

            _users = _userRepository.GetSingle(_users);

            WriteLine($"Welcome {_users.Name}.\n");

            if (_users != null) return;

            _users = new DAL.Models.Users {Name = userName};
            _userRepository.Add(_users);
            _users = GetUser(_users);

            WriteLine($"Welcome {_users.Name}.\n");
            
        }


        public Dictionary<string, Delegate> Comands { get; } = new Dictionary<string, Delegate>
        {
            {
                "Edit",
                new Action(() =>
                {
                    WriteLine("Input Name of contact");
                        var resName = ReadLine();
                        var rescontact = _contactRepository.GetSingle(x => x.Name == resName);

                        WriteLine("Input Field name to edit");
                        var editComand = ReadLine();

                        switch (editComand)
                        {
                            case "Name":
                                WriteLine("Input new Name");
                                rescontact.Name = ReadLine();
                                _contactRepository.Update(rescontact);
                                break;
                            case "Surname":
                                WriteLine("Input new Surname");
                                rescontact.Surname = ReadLine();
                                _contactRepository.Update(rescontact);
                                break;
                            case "Number":
                                WriteLine("Input Number");
                                var resNumber = ReadLine();
                                var phone = _phonesRepository.GetSingle(x => x.Number == resNumber);
                                WriteLine("Input new Number");
                                phone.Number = ReadLine();
                                WriteLine("Input Type");
                                phone.Type = ReadLine();
                                _phonesRepository.Update(phone);
                                break;
                            case "AddNumber":
                                var resphones = new List<DAL.Models.Phoness>();
                                do
                                {
                                    WriteLine("Input Number");
                                    var number = ReadLine();
                                    WriteLine("Input Type");
                                    var type = ReadLine();
                                    resphones.Add(new DAL.Models.Phoness
                                    {
                                        Number = number,
                                        Type = type
                                    });
                                    WriteLine("Press backspace to end.");
                                } while (ReadKey().Key != ConsoleKey.Backspace);
                                foreach (var ph in resphones)
                                {
                                    _phonesRepository.Add(ph);
                                }
                                break;
                        }
                })
            },
            {
                "Remove",
                new Action(() =>
                {
                    WriteLine("Input name");
                        var name = ReadLine();
                        WriteLine("Input surname");
                        var surname = ReadLine();
                        _contactRepository.Remove(
                            _contactRepository.GetSingle(x => x.Name == name && x.Surname == surname));
                })
            },
            {
                "Add",
                new Action(() =>
                {
                    WriteLine("Input Name");
                    var name = ReadLine();

                    WriteLine("Input Surname");
                    var surName = ReadLine();

                    var phones = new List<DAL.Models.Phoness>();

                    do
                    {
                        WriteLine("Input Number");
                        var number = ReadLine();
                        WriteLine("Input Type");
                        var type = ReadLine();
                        phones.Add(new DAL.Models.Phoness
                        {
                            Number = number,
                            Type = type
                        });
                    } while (ReadKey().Key != ConsoleKey.Backspace);

                    _contactRepository.Add(new DAL.Models.Contactss
                    {
                        UserId = _users.Id,
                        Name = name,
                        Surname = surName,
                        Phones = phones
                    });
                })
            },
            {
                "Show",
                new Action(() =>
                {
                    foreach (var contact in _contactRepository.GetList(x => x.UserId == _users.Id))
                    {
                        WriteLine($"Name {contact.Name}; Surname {contact.Surname}; Numbers : ");
                        foreach (var phone in _phonesRepository.GetList(x => x.ContactId == contact.Id))
                        {
                            WriteLine($"Number: {phone.Number}; Type: {phone.Type}");
                        }
                    }
                })
            },
            {
                "Help",
                new Action(() =>
                {
                    Clear();
                    WriteLine("1-Edit.\n2-Add.\n3-Remove.\n4-Show.\n");
                })
            }
            
        };

        private static DAL.Models.Users GetUser(DAL.Models.Users users)
        {
            return _userRepository.GetSingle(users);
        }
    }
}