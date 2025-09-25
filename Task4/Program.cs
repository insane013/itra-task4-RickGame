using Task4;
using Task4.RandomGenerator;
using Task4.UserInteractions;
using Task4.GameCore;
using Task4.Configuration;

if (!GameConfigurator.Configure(args, out GameConfigDto? config)) return;

if (config == null) return;

Console.WriteLine($"Boxes count: {GameConfigurator.BoxesCount}");
Console.WriteLine($"Morty implementation path: {GameConfigurator.MortyImplementationPath}");

IRandomNumberService randomGenerator = new FairRandomGenerator();
IUserInterface consoleUI = new ConsoleUI();

GameCore game = new GameCore(config, randomGenerator, consoleUI);

config.MortyInstance.Init(game, consoleUI, GameConfigurator.BoxesCount);

game.StartGame();