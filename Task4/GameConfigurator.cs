namespace Task4
{
    public static class GameConfigurator
    {
        public static int BoxesCount { get; private set; }
        public static string MortyImplementationPath { get; private set; } = string.Empty;

        public static bool ValidateArgs(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("You need pass boxes count and path to Morty's implementation as command line arguments!");
                Console.WriteLine("Example: Task4.exe 5 C:\\path\\to\\MortyImplementation.cs");
                Console.WriteLine("Remind: first argument is boxes count and should be integer number greater than 2.");
                return false;
            }

            bool isBoxesCorrect = int.TryParse(args[0], out int boxesCount);

            if (!isBoxesCorrect)
            {
                Console.WriteLine("Remind: first argument is boxes count and should be integer number greater than 2!");
                return false;
            }

            if (boxesCount <= 2)
            {
                Console.WriteLine("How u suppose to play with 2 or less boxes?! Provide me with boxes count greater than 2!");
                return false;
            }

            MortyImplementationPath = args[1];
            BoxesCount = boxesCount;

            return true;
        }
    }
}