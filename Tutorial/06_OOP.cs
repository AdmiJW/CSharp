// Work in progress lmao
// but most of them are similar in C++ and Java. You should be ok :)

// TODO: Class
// TODO: Overloading, Inheritance (base = super)
// TODO: Abstraction (interface, abstract)
// TODO: Enums, Struct


/*
    * ================================
    * 06_1 - Encapsulation
    * ================================
    https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties

    Encapsulation - private, getter, setter.

    In Java, if you want to implement encapsulation, you follow the steps:
    - Create private member
    - Create getter method
    - Create setter method

    Suddenly, your class is already having 10+ lines of code all for one single private variable. What pain.

    C# properties - The combination of above 3 steps into one, is the remedy for your pain.
    It look something like this:

            private int _age;
            public int Age {
                get {
                    return _age;
                }
                set {
                    _age = value;
                }
            }
    
    _age is the private variable that we are hiding away from the user. The user will access _age through obj.Age, which
    to them actually looks like a field, but is actually combination of getter and setter.
    Inside get, we have to return the requested value. Inside set, we have access to implicit 'value' which is the value client
    is trying to set to.

    For more concise syntax, we can use lambda expression here:

            private int _age;
            public int Age {
                get => _age;
                set => _age = value;
            }

    Want to abstract further? Don't want to declare a private variable? See:
    https://stackoverflow.com/questions/5096926/what-is-the-get-set-syntax-in-c
    
            public int Age { get; set; }
            
    ! However, you kind of losing the point of encapsulation if you do this. You basically have public access to Age now.
*/



/*
    * ================================
    * 06_2 - Polymorphism
    * ================================
    https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords

    Polymorphism in C# is very alike to C++. You have to use 'virtual' and 'override' keyword.

    Say we have a method foo() in our base class. You now create a derived class with also a foo() method in it without specifying
    virtual or anything. Now, if you do:
            Derived d = new Derived();
            d.foo();
            Base bd = new Derived();
            bd.foo();
    First you will notice a warning from the compiler. It will warn you about the Derived class's foo() method is hiding away that
    of base class's foo() method. If that is your intent, use 'new' keyword on the derived class foo() method, like:
            public new void foo() {...} 

    However, you will see that we haven't implement polymorphism yet because bd.foo() still runs that of base class's. Therefore,
    in the base class foo() method, we'll put virtual keyword on the function:
            public virtual void foo() {...}
    Then in Derived class, put the 'override' keyword
            public override void foo() {...}

    There you have it! Polymorphism.
*/






using System;


namespace T06_OOP {

    // Example of setter and getter - you only can set a valid value
    class Animal {
        private char _gender;
        public char Gender {
            get => _gender;
            set {
                if (value != 'M' && value != 'F')
                    throw new ArgumentException("Invalid Gender");
                _gender = value;
            }
        }


        public virtual void makeSound() {
            Console.WriteLine("Animal makes sound");
        }
    }


    // Inheritance and Polymorphism
    class Dog: Animal {
        public override void makeSound() {
            Console.WriteLine("Woof");
        }
    }



    class OOP {

        static void Main(string[] args) {
           Animal a = new Animal();
           a.Gender = 'F';
           Console.WriteLine(a.Gender);


           Animal d = new Dog();
           d.makeSound();
        }
    }
}