using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_book
{
    class Program
    {
        static void Main(string[] args)
        {
            User u1 = new User("Петя", new Terminal(new PhoneNumber("222-333-444")));
        }
    }
}
