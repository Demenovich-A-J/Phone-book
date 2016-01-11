using System.Linq;
using AutoMapper;
using Phone_book.DAL.Repositoys.AbstractClasses;
using Phone_book.DAL.Repositoys.Intarfaces;

namespace Phone_book.DAL.Repositoys
{
    public class PhonesRepository : GenericDataRepitory<Models.Phoness, Phones>, IPhonesRepository
    {
        public PhonesRepository()
        {
            Mapper.CreateMap<Models.Phoness, Phones>();
            Mapper.CreateMap<Models.Contactss, Contacts>();

            Mapper.CreateMap<Phones, Models.Phoness>();
            Mapper.CreateMap<Contacts, Models.Contactss>();
        }

        protected override Phones ObjectToEntity(Models.Phoness item)
        {
            return Mapper.Map<Phones>(item);
        }

        protected override Models.Phoness EntityToObject(Phones item)
        {
            return Mapper.Map<Models.Phoness>(item);
        }

        public override Models.Phoness GetSingle(Models.Phoness item)
        {
            Models.Phoness resItem;
            using (var context = new PhoneBookDB())
            {
                resItem = context
                    .Set<Phones>()
                    .Select(EntityToObject)
                    .FirstOrDefault(x => x.ContactId == item.ContactId);
            }
            return resItem;
        }
    }
}