namespace Phone_book
{
    public class User
    {
        public User(string name, ITerminal terminal)
        {
            Name = name;
            _terminal = terminal;
        }

        public string Name { get; }
        private ITerminal _terminal;
    }
}