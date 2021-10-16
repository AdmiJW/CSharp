using System;
using System.Text;
using static System.Diagnostics.Trace;

namespace CaesarsCipher {
    class CaesarsCipher {
        // As per freecodecamp's instruction, it only works with uppercase alphabets
        static string rot13(string s) {
            StringBuilder sb = new StringBuilder();
            // Shift every alphabetic characters by 13 places, while remain the non-alphabetic characters
            for (int i = 0; i < s.Length; ++i) {
                char c = s[i];
                if ( char.IsLetter(c) )
                    c = (char)( (c - 'A' + 13) % 26 + 'A');
                sb.Append(c);
            }
            return sb.ToString();
        }
        static void Main(string[] args) {
            Assert( rot13("SERR PBQR PNZC") == "FREE CODE CAMP", "1");
            Assert( rot13("SERR CVMMN!") == "FREE PIZZA!", "2");
            Assert( rot13("SERR YBIR?") == "FREE LOVE?", "3");
            Assert( rot13("GUR DHVPX OEBJA SBK WHZCF BIRE GUR YNML QBT.") == "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG.", "4");

            Console.WriteLine("Tests passed");
        }
    }
}