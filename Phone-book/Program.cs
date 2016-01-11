using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Phone_book.Configurators;
using static System.Console;

namespace Phone_book
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var comands = new ComandsConfig();

            do
            {
                WriteLine("Input Comand : ");
                var comand = ReadLine();

                if (comand != null)
                {
                    try
                    {
                        comands.Comands[comand].DynamicInvoke();
                    }
                    catch (KeyNotFoundException ex)
                    {
                        WriteLine(ex.Message);
                    }
                }
                WriteLine("Press backspace to exit.");
            } while (ReadKey().Key != ConsoleKey.Backspace);
        }
    }
}