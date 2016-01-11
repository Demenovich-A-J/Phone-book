using System.Linq;
using AutoMapper;
using Phone_book.DAL.Repositoys.AbstractClasses;
using Phone_book.DAL.Repositoys.Intarfaces;

namespace Phone_book.DAL.Repositoys
{
    public class ContactsRepository : GenericDataRepitory<Models.Contactss, Contacts>, IContactsRepository
    {
        public ContactsRepository()
        {
            Mapper.CreateMap<Models.Phoness, Phones>();
            Mapper.CreateMap<Models.Users, User>();
            Mapper.CreateMap<Models.Contactss, Contacts>();

            Mapper.CreateMap<User, Models.Users>();
            Mapper.CreateMap<Phones, Models.Phoness>();
            Mapper.CreateMap<Contacts, Models.Contactss>();
        }

        protected override Contacts ObjectToEntity(Models.Contactss item)
        {
            return Mapper.Map<Contacts>(item);
        }

        protected override Models.Contactss EntityToObject(Contacts item)
        {
            return Mapper.Map<Models.Contactss>(item);
        }

        public override Models.Contactss GetSingle(Models.Contactss item)
        {
            Models.Contactss resItem;
            using (var context = new PhoneBookDB())
            {
                resItem = context
                    .Set<Contacts>()
                    .Select(EntityToObject)
                    .FirstOrDefault(x => x.Name == item.Name && x.Surname == item.Surname);
            }
            return resItem;
        }
    }
}