using System;
using static System.Diagnostics.Trace;


namespace CashRegister {

    // A class representing the cash register. Contains the following (values):
    // penny - 0.01
    // nickel - 0.05
    // dime - 0.1
    // quarter - 0.25
    // dollar - 1
    // five - 5
    // ten - 10
    // twenty - 20
    // hundred - 100
    class CashRegister {
        public decimal penny, nickel, dime, quarter;
        public int dollar, five, ten, twenty, hundred;

        public CashRegister(decimal penny=0m, decimal nickel=0m, decimal dime=0m, decimal quarter=0m, int dollar=0, int five=0,
            int ten=0, int twenty=0, int hundred=0) {
                this.penny = penny;
                this.nickel = nickel;
                this.dime = dime;
                this.quarter = quarter;
                this.dollar = dollar;
                this.five = five;
                this.ten = ten;
                this.twenty = twenty;
                this.hundred = hundred;
        }

        public decimal getTotal() {
            return penny + nickel + dime + quarter + dollar + five + ten + twenty + hundred;
        }

        public bool isEqual(CashRegister other) {
            return penny == other.penny && nickel == other.nickel && dime == other.dime
                && quarter == other.quarter && dollar == other.dollar && five == other.five
                && ten == other.ten && twenty == other.twenty && hundred == other.hundred;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", penny, nickel, dime, quarter, dollar, five, ten, twenty, hundred);
        }
    }

    

    class Shop {
        static (string, CashRegister) checkCashRegister(decimal price, decimal cash, CashRegister cr) {
            decimal change = cash - price;
            decimal balance = cr.getTotal();

            if (balance < change) return ("INSUFFICIENT_FUNDS", new CashRegister());
            if (balance == change) return ("CLOSED", cr);

            CashRegister changeCash = new CashRegister();

            // Start deducting for changes
            // Hundred
            int hundredChange = (int)Math.Min( cr.hundred / 100, change / 100 ) * 100;
            change -= hundredChange;
            cr.hundred -= hundredChange;
            changeCash.hundred += hundredChange;

            // Twenties
            int twentiesChange = (int)Math.Min( cr.twenty / 20, change / 20 ) * 20;
            change -= twentiesChange;
            cr.twenty -= twentiesChange;
            changeCash.twenty += twentiesChange;

            // Tenths
            int tenthsChange = (int)Math.Min( cr.ten / 10, change / 10 ) * 10;
            change -= tenthsChange;
            cr.ten -= tenthsChange;
            changeCash.ten += tenthsChange;

            // Five
            int fiveChange = (int)Math.Min( cr.five / 5, change / 5 ) * 5;
            change -= fiveChange;
            cr.five -= fiveChange;
            changeCash.five += fiveChange;

            // Dollar
            int dollarChange = (int)Math.Min( cr.dollar / 1, change / 1 );
            change -= dollarChange;
            cr.dollar -= dollarChange;
            changeCash.dollar += dollarChange;

            // Quarter
            decimal quarterChange = (int)( Math.Min( cr.quarter / 0.25m, change / 0.25m ) ) * 0.25m;
            change -= quarterChange;
            cr.quarter -= quarterChange;
            changeCash.quarter += quarterChange;

            // Dime
            decimal dimeChange = (int)( Math.Min( cr.dime / 0.1m, change / 0.1m ) ) * 0.1m;
            change -= dimeChange;
            cr.dime -= dimeChange;
            changeCash.dime += dimeChange;

            // Nickel
            decimal nickelChange = (int)( Math.Min( cr.nickel / 0.05m, change / 0.05m ) ) * 0.05m;
            change -= nickelChange;
            cr.nickel -= nickelChange;
            changeCash.nickel += nickelChange;

            // Penny
            decimal pennyChange = Math.Min( cr.nickel, change );
            change -= pennyChange;
            cr.penny -= pennyChange;
            changeCash.penny += pennyChange;

            if (change != 0) return ("INSUFFICIENT_FUNDS", new CashRegister());
            return ("OPEN", changeCash);
        }



        static void Main(string[] args) {
            CashRegister[] tests = {
                new CashRegister(1.01m, 2.05m, 3.1m, 4.25m, 90, 55, 20, 60, 100),
                new CashRegister(1.01m, 2.05m, 3.1m, 4.25m, 90, 55, 20, 60, 100),
                new CashRegister(0.01m, 0m, 0m, 0m, 0, 0, 0, 0, 0),
                new CashRegister(0.01m, 0m, 0m, 0m, 1, 0, 0, 0, 0),
                new CashRegister(0.5m, 0m, 0m, 0m, 0, 0, 0, 0, 0)
            };
            CashRegister[] expects = {
                new CashRegister(quarter: 0.5m),
                new CashRegister(twenty: 60, ten: 20, five: 15, dollar: 1, quarter: 0.5m, dime: 0.2m, penny: 0.04m),
                new CashRegister(),
                new CashRegister(),
                new CashRegister(penny: 0.5m)
            };

            // Test cases:
            string status;
            CashRegister chg;
            
            (status, chg) = checkCashRegister(19.5m, 20m, tests[0]);
            Assert(status == "OPEN" && chg.isEqual(expects[0] ), "1");
            
            (status, chg) = checkCashRegister(3.26m, 100m, tests[1]);
            Assert(status == "OPEN" && chg.isEqual(expects[1] ), "2");

            (status, chg) = checkCashRegister(19.5m, 20m, tests[2]);
            Assert(status == "INSUFFICIENT_FUNDS" && chg.isEqual(expects[2] ), "3");

            (status, chg) = checkCashRegister(19.5m, 20m, tests[3]);
            Assert(status == "INSUFFICIENT_FUNDS" && chg.isEqual(expects[3] ), "4");

            (status, chg) = checkCashRegister(19.5m, 20m, tests[4]);
            Assert(status == "CLOSED" && chg.isEqual(expects[4] ), "5");

            Console.WriteLine("Tests Passed");
        }
    }
}