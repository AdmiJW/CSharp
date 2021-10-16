
/*
    * =======================
    * 02_1 - Datatypes
    * =======================
    In C#, datatypes can be categorized into 2 types:
        1. Value Types
        2. Reference Types

    Here's an interesting fact for you:
        ! Everything in C# is an object. Primitive types are object too.
    * Gasp *
    What does this mean? This means even integers has methods we can access:
        (102).ToString();
    Completely valid!

    Value Types are simply objects that directly contain value - No pointer and addressing stuff. See:
        - bool
        - sbyte (signed byte)
        - byte (unsigned byte)
        - short
        - ushort
        - int
        - uint
        - long
        - ulong
        - char
        - float
        - double
        - decimal (Even more precision than double - Best use for currency calculation)
    (You'll commonly use only less than half of these)

    Reference Types are simply object that contain references to other values. Object & Array is example of reference type.
*/


/*
    * =======================
    * 02_2 - Literals
    * =======================
    By default, integer literals are assumed to be int32. Add decimal point to it, it defaults to double. To specify otherwise,
    suffix it:
        - L (long)
        - f (float)
        - m (decimal)
        - '' (Enclosing a char)
        - "" (Encloding a string)
*/

/*
    * ==========================================
    * 02_3 - Type Inferencing and Dynamic Type
    * ==========================================
    Coming from Javascript or Python background? Don't like typing? There are ways in C#:

    - Use 'var' as type - Compiler will try its best to help you detect the suitable type. However, value must be directly
      assigned or compiler is going to complain:

        OK: var a = "This is a string";
        X : var a;

    - Use 'dynamic' - Like in Python, type is deduced at runtime. Means you can later reassigned it a value of different type.
*/

/*
    * ==========================================
    * 02_4 - References
    * ==========================================
    Pointer and References - Hated by C++ students, is in C#.
    However, pointers can only be used when you compile the code in unsafe context. Hardly ever we'll use pointers in C#

    HOWEVER, in methods and functions, we still is able to choose to pass a supposed-to-be ValueType by reference. This way
    we still is able to mutate ValueType arguments.

    > In function signature, the argument needs to be specified with 'ref' keyword
            void mutate( ref int n ) {...}
    > Then, when passing in arguments, also prefix with 'ref' keyword
            mutate( ref myNumber );
*/



using System;

namespace T02_Datatypes_and_Variables {
    class Datatypes_and_Variables {
        static void Main(string[] args) {
            bool isVariable = true;
            int n = 2;
            long l = 2147683649L;
            string s = "Hello";

            // Dynamic Datatype
            dynamic d = "Now I am string";
            Console.WriteLine(d);
            d = 12345;
            Console.WriteLine(d);

            // To prove everything is an object:
            Console.WriteLine( (12).ToString() );


            // Ref
            assign69( ref n );
            Console.WriteLine( n );
        }


        static void assign69(ref int toChange) { toChange = 69; }
    }
}