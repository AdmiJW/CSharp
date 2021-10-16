using System;
using System.Text;
using static System.Diagnostics.Trace;


namespace RomanNumeralConverter {
    class RomanNumeralConverter {
        static string toRomanNumeral(int n) {
            StringBuilder sb = new StringBuilder();
            
            // Handle Thousands: Keep appending 'M'
            for (int i = n / 1000; i > 0; --i)
                sb.Append('M');
            n %= 1000;

            // Handle Hundreds
            if (n / 100 == 9) sb.Append("CM");
            else if (n / 100 == 4) sb.Append("CD");
            else {
                if (n / 100 >= 5) sb.Append('D');
                for (int i = n / 100 % 5; i > 0; --i)
                    sb.Append('C');
            }
            n %= 100;

            // Handle Tenths
            if (n / 10 == 9) sb.Append("XC");
            else if (n / 10 == 4) sb.Append("XL");
            else {
                if (n / 10 >= 5) sb.Append('L');
                for (int i = n / 10 % 5; i > 0; --i)
                    sb.Append('X');
            }
            n %= 10;

            // Handle Ones
            if (n == 9) sb.Append("IX");
            else if (n == 4) sb.Append("IV");
            else {
                if (n >= 5) sb.Append('V');
                for (int i = n % 5; i > 0; --i)
                    sb.Append('I');
            }
            n %= 10;

            return sb.ToString();
        }


        static void Main(string[] args) {
            Assert( toRomanNumeral(2) == "II", "1");
            Assert( toRomanNumeral(3) == "III", "2");
            Assert( toRomanNumeral(4) == "IV", "3");
            Assert( toRomanNumeral(5) == "V", "4");
            Assert( toRomanNumeral(9) == "IX", "5");
            Assert( toRomanNumeral(12) == "XII", "6");
            Assert( toRomanNumeral(16) == "XVI", "7");
            Assert( toRomanNumeral(29) == "XXIX", "8");
            Assert( toRomanNumeral(44) == "XLIV", "9");
            Assert( toRomanNumeral(45) == "XLV", "10");
            Assert( toRomanNumeral(68) == "LXVIII", "11");
            Assert( toRomanNumeral(83) == "LXXXIII", "12");
            Assert( toRomanNumeral(97) == "XCVII", "13");
            Assert( toRomanNumeral(99) == "XCIX", "14");
            Assert( toRomanNumeral(400) == "CD", "15");
            Assert( toRomanNumeral(500) == "D", "16");
            Assert( toRomanNumeral(501) == "DI", "17");
            Assert( toRomanNumeral(649) == "DCXLIX", "18");
            Assert( toRomanNumeral(798) == "DCCXCVIII", "19");
            Assert( toRomanNumeral(891) == "DCCCXCI", "20");
            Assert( toRomanNumeral(1000) == "M", "21");
            Assert( toRomanNumeral(1004) == "MIV", "22");
            Assert( toRomanNumeral(1006) == "MVI", "23");
            Assert( toRomanNumeral(1023) == "MXXIII", "24");
            Assert( toRomanNumeral(2014) == "MMXIV", "25");
            Assert( toRomanNumeral(3999) == "MMMCMXCIX", "26");

            Console.WriteLine("Tests passed");
        }
    }
}