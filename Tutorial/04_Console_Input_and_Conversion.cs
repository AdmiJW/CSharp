/*
    * =======================
    * 04_1 - Type Conversions
    * =======================
    
    Old school type casting is still present. You should know what can be type casted this way and what's not from your past
    experiences with old school programming languages
    
        int i = (int)1.234;
        double d = (double)123;

    For types that cannot be type casted this way, fear not. Everything you are looking for is probably inside
    System.Convert class!

        int i = Convert.ToInt32("123");
        double d = Convert.ToDouble("12.34");

    Optionally, we may also choose to use the type class's parse() method:

        int i = int.parse("123");
*/

/*
    * =======================
    * 04_2 - Console Input
    * =======================
    
    You print strings to the console via System.Console.Write() and System.Console.WriteLine().
    In the same manner, you retrieve user inputs from the Console too:

    - Console.Read() - Reads 1 character only. Return int (ASCII)
    - Console.ReadLine() - Reads whole line. Return string
    - Console.ReadKey() - Wait for a key input. Returns ConsoleKeyInfo object.
*/


using System;

namespace T04_ConsoleInputAndConversions {
    class ConsoleInputAndConversions {

        static void Main(string[] args) {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32( Console.ReadLine() );

            Console.WriteLine($"Hello {name}. You'll be {age + 5} in 5 years!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}