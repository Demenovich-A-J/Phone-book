using System.Linq;
using Phone_book.DAL.Repositoys.AbstractClasses;
using Phone_book.DAL.Repositoys.Intarfaces;

namespace Phone_book.DAL.Repositoys
{
    public class UserRepository : GenericDataRepitory<User>, IUserRepository
    {
        public override User GetSingle(User item)
        {
            User resItem;
            using (var context = new PhoneBookDB())
            {
                resItem = context
                    .Set<User>()
                    .FirstOrDefault(x => x.Name == item.Name);
            }
            return resItem;
        }
    }
}