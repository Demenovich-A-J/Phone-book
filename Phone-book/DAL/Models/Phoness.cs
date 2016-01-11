namespace Phone_book.DAL.Models
{
    public class Phoness
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ContactId { get; set; }
        public string Type { get; set; }

        public virtual Contactss Contactss { get; set; }
    }
}