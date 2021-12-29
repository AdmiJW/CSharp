
/*
    * ================================
    * 07_1 - Generic Class and Methods
    * ================================
    https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics
    Generics : Encouraging code reuse with compliance of DRY principle

    Start your class with something like:

        class MyClass <T1, T2> {...}

    Then you can use T1 and T2 as your placeholder type in your class.
*/


/*
    * =======================
    * 05_2 - Generic Methods
    * =======================
    https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-methods
    
    Generics apply to methods too.

        static void Swap<T>( ref T left, ref T right ) {...}
*/


using System;
using System.Collections.Generic;


namespace T07_Generics {

    // Absolutely useless wrapper class for List, but demonstrates the use of generic class
    class ListWrapper <T> {
        private List<T> list;

        public ListWrapper() {
            list = new List<T>();
        }

        public void add(T item) {
            list.Add(item);
        }

        public void print() {
            Console.WriteLine( String.Join(",", list) );
        }
    }


    // A class that contains a swap method to show generic methods
    class GenericMethod {
        public static void swap<T>( ref T left, ref T right ) {
            T temp = left;
            left = right;
            right = temp;
        }
    }


    class Generics {

        static void Main(string[] args) {
            // Generic Class and Methods
            ListWrapper<string> li = new ListWrapper<string>();
            li.add("Hello");
            li.add("World");
            li.print();

            // Generic Method
            string l = "Left", r = "Right";
            GenericMethod.swap<string>( ref l, ref r );
            Console.WriteLine(l);
            Console.WriteLine(r);
        }
    }
}