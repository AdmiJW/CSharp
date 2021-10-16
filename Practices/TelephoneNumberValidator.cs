using System;
using System.Text.RegularExpressions;
using static System.Diagnostics.Trace;


namespace TelephoneNumberValidator {
    class TelephoneNumberValidator {
        // Regexp Explaination:
        // ^                                Start of Line
        // (?:1 ?)?                         Non capturing group: Optional start with country code '1' following by optional space
        // (?:\\d\\d\\d|\\(\\d\\d\\d\\))    Non capruting group: Can be either 3 bare digits, or 3 digits enclosed in brackets
        // [ -]?                            Followed by optional space or dash '-'
        // \\d{3}                           Followed by 3 digits
        // [ -]?                            Followed by optional space or dash '-'
        // \\d{4}                           Followed by 4 digits
        // $                                End of line


        static string pattern = "^(?:1 ?)?(?:\\d\\d\\d|\\(\\d\\d\\d\\))[ -]?\\d{3}[ -]?\\d{4}$";
        static Regex regexp = new Regex(pattern);

        static bool isValid(string s) {
            return regexp.IsMatch(s);
        }
        static void Main(string[] args) {
            Assert( isValid("555-555-5555"), "1");
            Assert( isValid("1 555-555-5555"), "2");
            Assert( isValid("1 (555) 555-5555"), "3");
            Assert( isValid("5555555555"), "4");
            Assert( isValid("555-555-5555"), "5");
            Assert( isValid("(555)555-5555"), "6");
            Assert( isValid("1(555)555-5555"), "7");
            Assert( !isValid("555-5555"), "8");
            Assert( !isValid("5555555"), "9");
            Assert( !isValid("1 555)555-5555"), "10");
            Assert( isValid("1 555 555 5555"), "11");
            Assert( isValid("1 456 789 4444"), "12");
            Assert( !isValid("123**&!!asdf"), "13");
            Assert( !isValid("55555555"), "14");
            Assert( !isValid("(6054756961"), "15");
            Assert( !isValid("2 (757) 622-7382"), "16");
            Assert( !isValid("0 (757) 622-7382"), "17");
            Assert( !isValid("-1 (757) 622-7382"), "18");
            Assert( !isValid("2 757 622-7382"), "19");
            Assert( !isValid("10 (757) 622-7382"), "20");
            Assert( !isValid("27576227382"), "21");
            Assert( !isValid("(275)76227382"), "22");
            Assert( !isValid("2(757)6227382"), "23");
            Assert( !isValid("2(757)622-7382"), "24");
            Assert( !isValid("555)-555-5555"), "25");
            Assert( !isValid("(555-555-5555"), "26");
            Assert( !isValid("(555)5(55?)-5555"), "27");
            Assert( !isValid("55 55-55-555-5"), "28");
        
            Console.WriteLine("Tests passed");
        }
    }
}