using System.Text;

namespace ConsoleAdventure.Controller
{
    class Console_Controller
    {
        static void Main(string[] args)
        {
            Console.Title = "Free Space Invaders!";

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.SetWindowSize(95, 35);
            Console.SetBufferSize(95, 35);

            Console.CursorVisible = false;
            Console.TreatControlCAsInput = true;

            // Festlegen der Konsolengröße
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            // Deaktivieren der Möglichkeit, die Konsolengröße zu ändern
            Console.Title = "Fixed Size Console";
            Console.TreatControlCAsInput = true;

            // Ausgabe einer Begrüßungsnachricht
            Console.WriteLine("Willkommen zu meiner einfachen C# Konsolenanwendung!");

            // Eingabeaufforderung für den Benutzernamen
            Console.Write("Bitte geben Sie Ihren Namen ein: ");
            string name = Console.ReadLine();

            // Ausgabe einer personalisierten Nachricht
            Console.WriteLine($"Hallo, {name}! Schön, Sie kennenzulernen.");

            // Programm wartet auf eine Eingabe, bevor es beendet wird
            Console.WriteLine("Drücken Sie eine beliebige Taste, um das Programm zu beenden...");
            Console.ReadKey();
        }
    }
}
