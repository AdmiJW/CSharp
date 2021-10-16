
using System;
using System.Text;
using static System.Diagnostics.Trace;

namespace Palindrome {
    class Palindrome {
        static bool isPalindrome(string s) {
            // Step 1: Remove all Non-alphanumeric characters,
            //         and turn everything into same case.
            StringBuilder sb = new StringBuilder();

            foreach (char c in s)
                if (char.IsLetterOrDigit(c)) sb.Append( char.ToLower(c) );

            // Step 2: Palindrome checking using two pointers
            int len = sb.Length;
            for (int i = 0; i < len / 2; ++i)
                if ( sb[i] != sb[len - i - 1] ) return false;
            return true;
        }

        static void Main(string[] args) {
            Assert( isPalindrome("eye"), "1" );
            Assert( isPalindrome("_eye"), "2" );
            Assert( isPalindrome("race car"), "3" );
            Assert( !isPalindrome("not a palindrome"), "4" );
            Assert( isPalindrome("A man, a plan, a canal. Panama"), "5" );
            Assert( isPalindrome("never odd or even"), "6" );
            Assert( !isPalindrome("nope"), "7" );
            Assert( !isPalindrome("almostomla"), "8" );
            Assert( isPalindrome("My age is 0, 0 si ega ym"), "9" );
            Assert( !isPalindrome("1 eye for of 1 eye"), "10" );
            Assert( isPalindrome("0_0 (: /-\\ :) 0-0"), "11" );
            Assert( !isPalindrome("five|\\_/|four"), "12" );

            Console.WriteLine("Test passed");
        }
    }
}