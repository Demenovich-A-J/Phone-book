using System.Collections.Generic;

namespace Phone_book
{
    public interface ITerminal
    {
        PhoneNumber Number { get; }
        ICollection<IContact> Contacts { get; }
        void Add(IContact contact);
        void Remove(IContact contact);

    }
}