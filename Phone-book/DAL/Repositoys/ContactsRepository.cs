using System.Linq;
using Phone_book.DAL.Repositoys.AbstractClasses;
using Phone_book.DAL.Repositoys.Intarfaces;

namespace Phone_book.DAL.Repositoys
{
    public class ContactsRepository : GenericDataRepitory<Contacts>, IContactsRepository
    {
        public override Contacts GetSingle(Contacts item)
        {
            Contacts resItem;
            using (var context = new PhoneBookDB())
            {
                resItem = context
                    .Set<Contacts>()
                    .FirstOrDefault(x => x.Name == item.Name && x.Surname == item.Surname);
            }
            return resItem;
        }
    }
}