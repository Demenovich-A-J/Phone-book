using System.Linq;
using AutoMapper;
using Phone_book.DAL.Repositoys.AbstractClasses;
using Phone_book.DAL.Repositoys.Intarfaces;

namespace Phone_book.DAL.Repositoys
{
    public class UserRepository : GenericDataRepitory<Models.Users,User>, IUserRepository
    {
        public UserRepository()
        {
            Mapper.CreateMap<Models.Users, User>();
            Mapper.CreateMap<Models.Contactss, Contacts>();

            Mapper.CreateMap<User, Models.Users>();
            Mapper.CreateMap<Contacts, Models.Contactss>();

        }

        protected override User ObjectToEntity(Models.Users item)
        {
            return Mapper.Map<User>(item);
        }

        protected override Models.Users EntityToObject(User item)
        {
            return Mapper.Map<Models.Users>(item);
        }

        public override Models.Users GetSingle(Models.Users item)
        {
            Models.Users resItem = null;
            using (var context = new PhoneBookDB())
            {
                resItem = context
                    .Set<User>()
                    .Select(EntityToObject)
                    .FirstOrDefault(x => x.Name == item.Name);
            }
            return resItem;
        }
    }
}