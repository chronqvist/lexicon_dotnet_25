// Uppgift: Checkpoint-1-Produktlista
// Lärare: ernst.ras1@lexutb.se
// Elev: fredrik@chronqvist.com

// Fråga:
// Skall jag fortsätta med PascalCase som du lär ut för variabler, eller kan jag ändra till
// camelCase som Visual Studio, Roslyn, Roslynator och StyleCop vill ha det?

/*
Jag får följande varningar från Visual Studio Community Edition 2026

Naming rule violation: The first word, 'Products', must begin with a lower case character
Naming rule violation: The first word, 'Continue', must begin with a lower case character
Naming rule violation: The first word, 'Input', must begin with a lower case character
Naming rule violation: The first word, 'Exit', must begin with a lower case character
Naming rule violation: The first word, 'Length', must begin with a lower case character
Naming rule violation: The first word, 'NumberOfDashes', must begin with a lower case character
Naming rule violation: The first word, 'StringMatch', must begin with a lower case character
Naming rule violation: The first word, 'ProductNameLeft', must begin with a lower case character
Naming rule violation: The first word, 'ProductNameRight', must begin with a lower case character
Naming rule violation: The first word, 'LeftLettersOnly', must begin with a lower case character
Naming rule violation: The first word, 'RightDigitsOnly', must begin with a lower case character
Naming rule violation: The first word, 'RightValue', must begin with a lower case character
Naming rule violation: The first word, 'Product', must begin with a lower case character

Chatgpt: Varför får du varningarna?

De kommer från .NET-analyserare (StyleCop eller Visual Studio inbyggda analyzers).
Regeln säger:

Variabelnamn ska börja med liten bokstav (camelCase)

Du använder t.ex.:

List<string> Products
bool Continue
string Input
bool Exit
int Length
int NumberOfDashes
Match StringMatch

Alla dessa bryter mot standardregeln:
camelCase för variabler och fält
PascalCase används bara för klasser, metoder, egenskaper

Därför klagar analysverktyget.
 */

/*
En annan fråga: Spelar det någon roll för prestanda eller läsbarhet om hur jag strukturerar mina if-satser?
Har du några önskemål kring användandet av if-satser
Läroböcker jag läst använder nästlad. Alla arbetsgivare som jag har haft och som är intresserade
av prestanda så används flera if-satser i följd med continue/goto för att undvika nästling. Goto används
för att hoppa till slutet av en funktion där uppstädning sker som tex stänga filer och frigöra resurser.

jag har använt min av nästladade if-satser enligt
if ()
{
} 
else 
{ 
    if () {
        if
    } 
    else if () {
    } 
    else {

}


Chatgpt vill att man gör så här:

if ()
{
    ...
    ...
    contine
}
if ()
{
    ...
    ...
    contine
}
if ()
{
    ...
    ...
    contine
}

Personligen tycker jag att det blir mycket mer läsbart med onästalde if-satser dvs jag är överens med Chatgpt.
*/

using System.Text.RegularExpressions;

List<string> Products = new List<string>();
Console.WriteLine("Skriv in produkter.Avsluta med att skriva 'exit'");
bool Continue = true;
do
{
    Console.Write("Ange produkt: ");
    string Input = Console.ReadLine();
    // För att avsluta: ordet "exit" med stora eller små bostäver. Ok med whitespace före och efterordet
    bool Exit = Regex.IsMatch(Input, @"^\s*exit\s*$", RegexOptions.IgnoreCase);
    if (Exit)
    {
        Continue = false;
    }
    else
    {
        int Length = Input.Length;
        int NumberOfDashes = Regex.Matches(Input, @"-").Count;

        if (Length == 0)
        {
            Console.WriteLine("Du får inte ange ett tomt värde");
        }
        else if (NumberOfDashes != 1)
        {
            Console.WriteLine("Produktnumret måste innehålla ett bindestreck");
        }
        else
        {
            // Format på korrekt produktnummer: Minst en bokstav (a-z, stor eller liten), följt av ett bindestreck och slutligen ett tal
            // Talet skall vara mellan 200-500
            Match StringMatch = Regex.Match(Input, @"(.*)-(.*)");
            string ProductNameLeft = StringMatch.Groups[1].Value;
            string ProductNameRight = StringMatch.Groups[2].Value;
            bool LeftLettersOnly = Regex.IsMatch(ProductNameLeft, @"^[a-zA-Z]+$");
            bool RightDigitsOnly = Regex.IsMatch(ProductNameRight, @"^[0-9]+$");
            int RightValue = -1;
            if (RightDigitsOnly)
            {
                RightValue = Convert.ToInt32(ProductNameRight);
            }
            if (!LeftLettersOnly)
            {
                Console.WriteLine("Felaktigt format på vänstra delen av produktnumret");
            }
            else if (!RightDigitsOnly)
            {
                Console.WriteLine("Felaktigt format på högra delen av produktnumret");
            }
            else if (RightValue < 200 || RightValue > 500)
            {
                Console.WriteLine("Den numeriska delen måste vara mellan 200 och 500");
            }
            else
            {
                Products.Add(Input);
            }

        }
    }
} while (Continue);

Products.Sort();
Console.WriteLine("Du angav följande produkter:");
foreach (var Product in Products)
{
    Console.WriteLine(Product);
}
