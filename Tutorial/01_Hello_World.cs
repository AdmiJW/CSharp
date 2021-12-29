/*
    When C++ and Java combine, it becomes C#.
    When learning C#, you will sometimes see it resembles C++, while the other times, you see it resembles Java...
*/


/* 
    * ==================================
    * 01_1 - .NET framework
    * ==================================

    C# is very tightly associated with .NET framework. .NET framework stands for Network Enabled Technology, while the
    dot (.) means object oriented. It is simply a framework for building applications on the windows. For example,
    ASP.NET (Active Server Pages) is framework from microsoft for building web applications.

    .NET framework consists of 2 major components:

    * Common Language Runtime (CLR) - Execution engine that handles running applications. Thread management, Garbage 
    *                                 collection, Type-Safety, Exception Handling and stuff.
    * Class Library - Set of APIs and types for common functionality. You'll see most of them under `System` namespace.

    .NET applications can be written under C#, F# or Visual Basic programming language. Code will be compiled into a
    language-agostic Common Intermediate Language (CIL) stored in assemblies (.dll or .exe). When the application runs,
    CLR takes the assembly and use a JIT (Just In Time Compiler) to translate into machine code.

    ? Does this look like how Java program is executed (source > bytecode > JVM)? Because it kinda is!

    Let's take a look at the below Hello World program in C#, and I will explain about each line:
*/



//? Like "using namespace std" in C++, like import java.* from Java
using System;


namespace T01_Hello_World {
    class HelloWorld {
        static void Main(string[] args) {
            
            //* If we do not put "using System", we would need System.Console.WriteLine();
            Console.WriteLine("Hello World!");          

            Console.WriteLine("The time now is: {0}", System.DateTime.Now );
            Console.WriteLine("You are currently on machine: {0}", System.Environment.MachineName );
        }
    }
}

/*
    * ===========================
    * 01_2 - Casing Convention
    * ===========================
    Immediately, you might notice that C# likes to use PascalCase rather than camelCase. Almost every standard method
    that you'll encounter is written using PascalCase (Even the Main() method). 
    Suit yourself. Perhaps this is an attempt from C# to make itself more distinct than Java?
*/

/*
    * ===========================
    * 01_3 - Namespaces
    * ===========================

    In C#, we will be introduced to the concept of `namespace` (Which is also present in C++ or other languages).
    A namespace is simply a container for related classes. For example, `System` is also a namespace, which inside would 
    contain a bunch of other nested namespaces, or classes that we may or may not use in our application.

    A great start to understand namespaces is as follows:
        - System is a namespace provied by .NET API which contains many classes to create your application. One of the classes
          inside the System namespace that we'll use, is the 'Console' class. The Console class contains 'WriteLine()' method
          we use to print strings out to the console!

          To see the full reference, visit https://referencesource.microsoft.com/

    System
    |- Console
        |- WriteLine()
    |- Many other useful classes...

    BTW, if you do not put a class inside a namespace, it will by default belong to the global namespace.
    const obj = new global::MyClass();
    > https://stackoverflow.com/questions/25491518/what-namespace-will-a-class-have-if-no-namespace-is-defined



    * ===========================
    * 01_4 - Importing Namespaces
    * ===========================

    Now in our application, we want to import classes from the 'System' namespace and perhaps, other .cs files that contain
    classes that we want to use.

    To achieve this, we use the 'using' keyword (Note that it can also be used as preprocessor directive). We simply type
    the namespace that we want included, and during compilation, it will look through our application to locate the corresponding
    namespace to import!

    Say we want to import the namespace system:
            using System;
    Then, we can write this:
            Console.WriteLine("Hello World");
    instead of typing full-fledged name:
            System.Console.WriteLine("Hello World");
        
    This is actually kinda like 'using namespace std' in C++. There is certainly controversials whether to use it or not.

    ! PS: I am using Visual Studio Code with CS-Script Extension (https://github.com/oleg-shilo/cs-script.vscode).
    ! This extension allows for running cs scripts without setting up a project, and even include scripts via comments:
    ! Like:
    !        "//css_include <filename>"
    ! But if you want to set up the project, see https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code


    * =====================================
    * 01_5- Importing Class Static Members
    * =====================================
    You might be wondering if its possible to take a step further, and to only write:
        WriteLine("Hello World");

    Yes, and this is called static import. This allows us to import static members of a class and made available to our code:
        import static System.Console;
    With this line, everything static in 'System.Console' will be imported and ready to be used!
*/