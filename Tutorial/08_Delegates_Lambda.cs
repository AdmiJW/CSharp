
/*
    * ================================
    * 08_1 Delegates
    * ================================
    In Javascript or python, functions are first class citizens - They can be assigned to variable, passed into parameters etc.
    In C++, we have function pointers, which keeps a reference to the function/method which similarly, we can treat it like
    variables.

    In C#, they are called delegates. There are 2 steps to get started with delegates:
    1. Declare the delegate - Specify return type and parameters
    2. Instantiate the delegate and assign a function/method to it.

    The syntax for declaring a delegate goes:
        <access specifier> delegate <return type> <delegate-name> <parameter list>
    Like:
        public delegate int MyDelegate (string s);

    Then, once our delegate type is declared, we can now instantiate it and assign it a reference to some method.

        MyDelegate delegate = SomeMethodWithSameSignature;
        delegate("Hello World");

    As an starter example, you may choose to do so to 'wrap' the Console.WriteLine()
        
        MyDelegate print = Console.WriteLine;
        print("Hello World");
*/


/*
    * ================================
    * 08_2 Anonymous Functions
    * ================================
    Ah yes, functions that doesn't have a name. In C# we can achieve this by delegate too.

    Previously, we learnt how to declare a delegate, and how we are using them is by assigning them some named method
    that already exists somewhere in our application. Eg:
            MyDelegate delegate = Console.WriteLine;

    What if I don't want to use delegate without having to write out a named function somewhere? Anonymous functions!
    In Java sadly, an anonymous function still require an interface to be implemented, like:

    ? (Java Code)
            interface IntegerCompute {
                int operation(int a, int b);
            }
            ...
            IntegerCompute adder = (a,b)-> a + b;
    ? (End of Java Code)
    

    In C# however, no need for all that code! Look how can I make an anonymous function out of delegates:

            delegate int IntegerCompute(int a, int b);
            IntegerCompute adder = delegate (int a, int b) {
                return a + b;
            }

            Console.Write( adder(1,2) );

    Using the 'delegate' keyword, I can immediately create a function without a name - Anonymous functions!
    Note that I don't even have to specify the return type. It is inferred automatically from the return statement in the body.
*/


/*
    * ================================
    * 08_3 Func and Action
    * ================================
    https://docs.microsoft.com/en-us/dotnet/api/system.func-2?view=net-5.0

    Even the idea of having to declare the delegate bothers me. Can't I eliminate the following line?
            public delegate int IntegerCompute(int a, int b);
    
    Yes. Directly under System namespace, we have Func<> and Action<>. They are here to help you avoid writing
    delegate declaration, albeit with the cost of losing the ability to write meaningful delegate typenames.

    Let's be clear - Func<> is for functions/methods that DID have a non-void return value. In the generic list,
    the last argument is always the return type.
    For example, our IntegerCompute would be declared like this:

            Func<int, int, int> adder = delegate (int a, int b) {
                return a + b;
            }
    First two 'int' is the parameter type, and the last 'int' is the return type of the function

    Whereas, Action<> is for methods/functions returning void. No return type in generic list.
    For example, our wrapper for Console.WriteLine():

            Action<string> print = delegate(string s) {
                Console.WriteLine(s);
            }
*/

/*
    * ================================
    * 08_4 Lambda Expressions
    * ================================
    What? Even using delegate keyword to create anonymous function is too annoying? Say no more: Lambda Expressions ;)

            Func<int,int,int> adder = (a, b)=> a + b;

            Action<string> print = (s)=> Console.WriteLine(s);
*/




using System;


// Here we declare a delegate
delegate string MessageDecorator(string message);


namespace T08_DelegatesLambda {
    class DelegatesLambda {

        static string DashMessageDecorator(string message) {
            return "---" + message + "---";
        }


        
        static void Main(string[] args) {

            // 1 - Pure delegate
            MessageDecorator dashDeco = DashMessageDecorator;
            Console.WriteLine( dashDeco("Hello World" ) );


            // 2 - Anonymous functions
            MessageDecorator plusDeco = delegate (string message) {
                return "+++" + message + "+++";
            };
            Console.WriteLine( plusDeco("Hello World" ) );


            // 3 - Using Func
            Func<string, string> bracketDeco = delegate (string message) {
                return "(((" + message + ")))";
            };
            Console.WriteLine( bracketDeco("Hello World" ) );


            // 4 - Lambda Expression
            Func<string, string> angleDeco = (message)=> {
                return "<<<" + message + ">>>";
            };
            Console.WriteLine( angleDeco("Hello World" ) );
        }
    }
}