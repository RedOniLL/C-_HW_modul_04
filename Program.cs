namespace C__HW_modul_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter choice");
            int c = int.Parse( Console.ReadLine());

          switch (c)
            {
                case 0:
                    Console.WriteLine("Welcome to Tic Tac Toe!");
                    Console.WriteLine("Choose game mode:");
                    Console.WriteLine("1. Player vs Computer");
                    Console.WriteLine("2. Player vs Player");
                    int choice = int.Parse(Console.ReadLine());

                    C__HW_modul_04.NewFolder.TicTacToe game;

                    switch (choice)
                    {
                        case 1:
                            game = new C__HW_modul_04.NewFolder.TicTacToe(true);
                            break;
                        case 2:
                            game = new C__HW_modul_04.NewFolder.TicTacToe(false);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Defaulting to Player vs Player.");
                            game = new C__HW_modul_04.NewFolder.TicTacToe(false);
                            break;
                    }

                    game.Play();
                    break;

                case 1:
                    Console.WriteLine("Enter text to translate to Morse code:");
                    string inputText = Console.ReadLine();

                    string morseCode = C__HW_modul_04.NewFolder.Morze.TextToMorse(inputText);
                    Console.WriteLine($"Morse code: {morseCode}");

                    Console.WriteLine("\nEnter Morse code to translate to text:");
                    string inputMorse = Console.ReadLine();

                    string plainText = C__HW_modul_04.NewFolder.Morze.MorseToText(inputMorse);
                    Console.WriteLine($"Plain text: {plainText}");
                    break;

            }
        }
    }
}
