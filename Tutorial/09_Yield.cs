using System;
using System.Collections.Generic;


/*
    * ================================
    * 09_1 - NO Yield
    * ================================
    https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/yield
    
    If you come from Python background and know how to use its 'yield' functionality (Generator), then this
    shouldn't be too hard for you.

    Imagine we have some large (or even theoretically infinite) collection of data, and we want to iterate through
    it in our program. However, since there is a possibility that we'll only use a fraction of the data (Especially
    if the data could be infinite sequence), do we really have to retrieve all of that data, load it into our memory all
    at once?

    Imagine this scenario:
        We are scientists making some heavy computations. Every computation would depend on previous value's output value
        (Recursion). -- In this example, I will use Fibonacci number computation as example.
        Say we want to iterate until iteration N and for each of the N, perform some operations on it, like logging on 
        the console, display on screen, etc.
    Let's see the implementation without yield (Enumerator):
*/


namespace T09_Yield {
    class NoIteratorComputation {
        public static List<double> computeFibonacci(int iterations) {
            List<double> result = new List<double>(iterations);
            if (iterations == 0) return result;
            result.Add(0);
            if (iterations == 1) return result;
            result.Add(1);
            if (iterations == 2) return result;

            // Since I use DP here, the performance is not expensive.
            // However, feel free to imagine that each iteration is expensive, performance-wise
            for (int i = 2; i <= iterations; ++i)
                result.Add( result[i-2] + result[i-1] );
            return result;
        }
    }
}



/*
    * ================================
    * 09_2 - Yield (Enumerator)
    * ================================
    Here are some downsides to the above implementation:
        >   All computations have to be done first, stored in a list, returned, then only we start processing all numbers
        >   Imagine if computation phase is heavy - It would take hours if not days to compute, ONLY THEN WE START PROCESSING
            OUR FIRST NUMBER!
        >   WHAT IF: In some conditions if a certain computation value will cause us to break out of the iteration, that would
            be computations wasted! We wouldn't compute so much if we know the current value will break the iteration!

    The core idea of iterator is: Only giving you values at the time you need it.
    Instead of compute the value all at once and returning it as list, when you ask for the next value, only the enumerator
    will compute the next value, and return the next value to you.

    The differences:
        NO ENUMERATOR:
            (COmpute all values and store in List) -> (Return list) -> (Process each number, potentially breaking out
            of iteration, wasting the rest of values)

        ENUMERATOR:
            (Compute value) -> (Return value) -> (Process value) -> (Next value?)
                ^                                                   |
                |---------------------------------------------------|

    Advantages:
        - Value is only computed when you needed it - No wasted computations!
        - Same way of usage - In a foreach loop
        - Values can be processed immediately after you yield one value. No long waiting!
        - Saves memory (If the computation yields large answer space)

    ==============================================================================================

    To get started, your function will return a IEnumerator<type> instead of previously List<double>.
    Then, in your function, whenever you want to return a computed value, use

            yield return <value>
    
    Also, when you want to indicate that it is the end of iteration, you can use

            yield break;

    Alternatively, the iteration also ends when the function ends (All codes executed)

    See example below:
*/

namespace T09_Yield {
    class IteratorComputation {
        public static IEnumerable<double> computeFibonacci(int iterations) {
            if (iterations == 0) yield break;
            yield return 0;
            if (iterations == 1) yield break;
            yield return 1;
            
            double prev1 = 0;
            double prev2 = 1;
            for (int i = 2; i <= iterations; ++i) {
                double res = prev1 + prev2;
                Console.WriteLine($"Computed iteration {i} = {res}");
                yield return res;
                prev1 = prev2;
                prev2 = res;
            }
        }
    }
}




namespace T09_Yield {

    class Yield {
        static void Main(string[] args) {
            // Here we compute up until 10. Imagine if we require millions of computations?

            // Without Enumerator/yield
            List<double> computed1 = NoIteratorComputation.computeFibonacci(10);
            Console.WriteLine("Everything is Computed and Returned as List");
            foreach (var i in computed1) 
                Console.WriteLine( $"Process: {i}");

            Console.WriteLine( "\n=========================================\n");
            
            // With Enumerator/yield
            IEnumerable<double> computed2 = IteratorComputation.computeFibonacci(10);
            foreach (var i in computed2) 
                Console.WriteLine( $"Process: {i}");
        }
    }
}
