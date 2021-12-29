# Create .NET Projects with Visual Studio Code

[__REFERENCE__](https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code)

If you have read the guides in the Tutorial directory, you should know that C# is compiled to CIL (Common Intermediate Language), then it is compiled to native bytecode through JIT (Just in time interpreter). Therefore, you cannot simply create a `.cs` script and run it. It needs to be built first. Here, we'll show how to set up in Visual Studio Code quickly in few steps.

---

## 1 - Setup

In the directory for your project, open the terminal and run the following:

```
dotnet new console --framework net6.0
```

This will set up a console application for you. There are other types of application, like `webapp` using ASP.NET for web applications

## 2 - Changing the default C# Code

The `Program.cs` serves as the entry point of your application. Go ahead and change the content to:

```cs
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```


## 3 - Running the application

Back in the terminal, simply:

```
dotnet run
```

---

Congratulations. Now add C# to your resume.