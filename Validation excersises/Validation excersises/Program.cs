using System.Text.RegularExpressions;

namespace Validation_excersises
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        //if else brukes til å sjekke en betingelse og utføre handlinger basert på det. Det kan også brukes for å sjekke enkle unntaker.
        static void ValidationOfInput(string input)
        {
            Console.WriteLine("Din alder er din input");
            bool IsValidAge = true;

            while (IsValidAge)
            {
                if (int.TryParse(input, out int age))
                {
                    if (age >= 18)
                    {
                        Console.WriteLine("Du er gammel nok til å stemme");
                        IsValidAge = false;
                    }
                    else
                    {
                        Console.WriteLine("Du er ikke gammel nok til å stemme");
                        IsValidAge = false;
                    }
                }
                else
                {
                    //Console.WriteLine("Ugyldig inndata");
                    throw new ArgumentException("Ugyldig data. vennligst skriv inn på nytt");
                }

            }
        }

        static void PasswordStrengthValidation()
        {
            Console.WriteLine("Skriv inn et passord");
            string password = Console.ReadLine();

            if (IsStrongPassword(password))
            {
                Console.WriteLine("Passordet er sterkt");
            }
            else
            {
                Console.WriteLine("Passordet er for svakt");
            }
        }

        static bool IsStrongPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.\d).8{8,}$");
        }

        //Try catch brukes når man forventer at det kan komme ugyldige input. Brukes på enkle og avanserte unntaker.

        static void DivideByZeroTryCatch()
        {
            try
            {
                int result = Divide(10, 0);
                Console.WriteLine("Resultatet er: " + result);
            }
            catch (DivideByZeroException ex)
            {
                throw new DivideByZeroException("Kan ikke dele på null");
            }
        }

        static int Divide(int numerator , int denominator)
        {
            return numerator / denominator;
        }

        static void ConvertStringToIntTryCatch()
        {
            try
            {
                string input = "abc";
            }
            catch (FormatException ex)
            {
                throw new FormatException("Kan ikke konvertere strengen til tall. Feilmelding: " + ex.Message);
            }
        }
    }
}
