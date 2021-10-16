
/*
    * =======================
    * 03_1 - Strings
    * =======================
    Strings - Array of chars. In C++ it is mutable, in Java it isn't.
    Surprisingly, in C#, string is immutable.
    However, like C++ you still can get character at index i via square brackets:
            s[0] 
    Gets first character in string s.

    Since Strings are immutable, we should be using StringBuilder class to manipulate strings, like in Java:
    (StringBuilder is located in System.Text.StringBuilder)
            using System.Text;
            ...
            StringBuilder sb = new StringBuilder();
            ...
*/

/*
    * ==============================================
    * 03_2 - String Formatting and Interpolation 
    * ==============================================
    First of all, string formatting:
        String.format( format, args... );
    Like:
        String.format( "{0} {1}", 1000, "Hello" );
        >> 1000 Hello
    It is built into Console.Write() and Console.WriteLine():
        Console.WriteLine("{0} {1}", 1000, "Hello");
        >> 1000 Hello

    
    Starting C# 6, you can have string interpolation - very neat:
        int n = 1000;
        string s = "Hello";
        
        string inter = $"{n} {s}";
        Console.WriteLine(inter);

        >> 1000 Hello
*/



using System;
using System.Text;

namespace T03_Strings {
    class Strings {
        static void Main(string[] args) {
            double first = 12;
            double second = 2.5173123;
            double third = .899;

            // { 0: c } - 0 is position of argument (required), c means currency format
            // 00.00 means minimum 2 digits (will pad with 0) and round to 2 decimal points

            // Composite formatting
            string f = String.Format("{0:c} {1:00.00} {2:.00}", first, second, third);
            Console.WriteLine(f);
            // String interpolation
            f = $"{first:c} {second:00.00} {third:.00}";
            Console.WriteLine(f);
        }
    }
}