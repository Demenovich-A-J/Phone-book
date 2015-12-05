using System.Linq;
using Phone_book.DAL.Repositoys.AbstractClasses;
using Phone_book.DAL.Repositoys.Intarfaces;

namespace Phone_book.DAL.Repositoys
{
    public class PhonesRepository : GenericDataRepitory<Phones>, IPhonesRepository
    {
        public override Phones GetSingle(Phones item)
        {
            Phones resItem;
            using (var context = new PhoneBookDB())
            {
                resItem = context
                    .Set<Phones>()
                    .FirstOrDefault(x => x.ContactId == item.ContactId);
            }
            return resItem;
        }
    }
}