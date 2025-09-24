using Task4;
using Task4.RandomGenerator;
using Task4.UserInteractions;

if (!GameConfigurator.ValidateArgs(args)) return;

Console.WriteLine($"Boxes count: {GameConfigurator.BoxesCount}");
Console.WriteLine($"Morty implementation path: {GameConfigurator.MortyImplementationPath}");

IRandomNumberService randomGenerator = new PFCCSRandomGen();

GameCore game = new GameCore(randomGenerator, new ConsoleUI());
game.StartGame();