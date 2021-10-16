/*
    * =======================
    * 05_1 - Arrays
    * =======================
    
    The way you create arrays in C# is a lot similar like Java. You may choose to use the new keyword, or directly initialize
    an array

        string[] arr = { "A", "B", "C" };
        int[] arr = new int[100];

    HOWEVER, multidimentional arrays are quite different. We have:
        1. Jagged arrays (Array of arrays)
        2. Multidimensional arrays

    Jagged arrays:
        int[][] m = { {1,2}, {3,4} };
        int[][] a = new int[4][];
        a[0] = new int[3];

    Multidimensional arrays:
        int[,] data = new int[3,4];
        int d = data[1,2];              // Access like this
*/


/*
    * =======================
    * 05_2 - Collections
    * =======================
    
    Yes, Data Structures.

    All of them can be found in System.Collections namespace.
    ! HOWEVER, you are more recommended to use those in System.Collections.Generic !
    Use them like you are used to in Java or C++.

    - List - ArrayList
    - LinkedList
    - HashSet
    - Stack
    - Queue
    - Dictionary - HashMap
*/


using System;
using System.Collections.Generic;


namespace T05_ArrayAndCollections {
    class ArrayAndCollections {

        // Jagged array example
        static void Main(string[] args) {
            // Jagged array example
            int[][] jag = new int[2][];
            jag[0] = new int[] {1,2,3,4,5};
            jag[1] = new int[] {6,7,8};
            // ? BTW, did I mention foreach loop looked like this?
            foreach( var row in jag )
                Console.WriteLine( String.Join(",", row) );


            // Multidimensional array example
            int[,] mult = new int[2,4] { {1,2,3,4}, {5,6,7,8} };
            foreach( var i in mult )
                Console.Write($"{i} ");
            Console.WriteLine();



            // Collections Example
            List<int> arr = new List<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.ForEach(x => Console.Write(x)); // I haven't covered lambda functions?
            Console.WriteLine();
            

            // Dictionary example
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "one");
            dict.Add(2, "two");
            foreach (var d in dict)
                Console.WriteLine($"{ d.Key } == { d.Value } ");
        
        }
    }
}