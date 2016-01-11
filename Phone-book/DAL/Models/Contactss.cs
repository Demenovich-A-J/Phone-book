using System.Collections.Generic;

namespace Phone_book.DAL.Models
{
    public class Contactss
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UserId { get; set; }

        public virtual Users Users { get; set; }
        public virtual ICollection<Phoness> Phones { get; set; }
    }
}