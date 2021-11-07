using System;

namespace HM3_3_Converter
{
    class Converter
    {
        private double usd;
        private double eur;

        public Converter(double usd, double eur)
        {
            this.usd = usd;
            this.eur = eur;
            Console.WriteLine("Done!");
        }
        public void ChoiceOfCurrencies()
        {
            double amount = 0, convertedAmount = 0;
            string currencyOfAmount = string.Empty, toCurrency = string.Empty;
            bool flagToContinue = true;
            while (flagToContinue)
            {
                Console.Write("Enter your amount: ");
                amount = double.Parse(Console.ReadLine());

                Console.Write("Now enter the currency of this amount" +
                    "(\"USD\" or \"EUR\" or \"UAH\"): ");
                Verification(ref currencyOfAmount);
                Console.Write("Then enter the currency you want: ");
                Verification(ref toCurrency);
                SelectionCheck(ref currencyOfAmount, ref toCurrency);

                if(currencyOfAmount == "USD")
                {
                    convertedAmount = GetCurrency(amount, usd);
                }
                else if(currencyOfAmount == "EUR")
                {
                    convertedAmount = GetCurrency(amount, eur);
                }
                else if(currencyOfAmount == "UAH")
                {
                    convertedAmount = GetCurrency(amount, toCurrency);
                }
                Console.WriteLine($"Converted amount {currencyOfAmount} to " +
                    $"{toCurrency}: {convertedAmount}");

                Console.WriteLine("Do you want to continue?(Just enter \"Y\", " +
                    "enter another to close.): ");
                if (Console.ReadLine() == "Y")
                    continue;

                flagToContinue = false;

                Console.WriteLine("Thank you for using the service.");
            }
        }
        public double GetCurrency(double amount, double toUAH)
        {
            return amount * toUAH;
        }
        public double GetCurrency(double amount, string toForeignCurrency)
        {
            if (toForeignCurrency == "USD")
                return amount / usd;
            else
                return amount / eur;
        }
        
        public void SelectionCheck(ref string currencyOfAmount, ref string toCurrency)
        {
            while(currencyOfAmount == toCurrency)
            {
                Console.Write("You have selected the same currencies." +
                    " Choose another one: ");
                Verification(ref toCurrency);
            }
        }
        public void Verification(ref string check)
        {
            bool wrongs = true;
            while(wrongs)
            {
                check = Console.ReadLine();
                if (check != "USD" && check != "EUR" && check != "UAH")
                {
                    Console.Write("Currency input error," +
                        " the case of letters is important. Try again: ");
                    continue;
                }
                wrongs = false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter currently exchange rate USD to UAH: ");
            double USDtoUAH = double.Parse(Console.ReadLine());
            Console.Write("Enter currently exchange rate EUR to UAH: ");
            double EURtoUAH = double.Parse(Console.ReadLine());

            Converter rate = new(USDtoUAH, EURtoUAH);
            rate.ChoiceOfCurrencies();
        }
    }
}
