namespace Phone_book
{
    public class PhoneNumber
    {
        private string _number;

        public PhoneNumber(string number)
        {
            _number = number;
        }

        public string Number => _number;
    }
}