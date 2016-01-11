using System.Collections.Generic;

namespace Phone_book.DAL.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Contactss> Contacts { get; set; }
    }
}