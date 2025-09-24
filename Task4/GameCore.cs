using Task4.UserInteractions;
using Task4.RandomGenerator;

namespace Task4
{
    public class GameCore
    {
        private IRandomNumberService _randomNumberService;
        private IUserInterface _ui;

        private List<GenerationRevealDTO> _roundGenerations = new List<GenerationRevealDTO>();

        private int rickGuess;
        private bool isSwitching;

        public GameCore(IRandomNumberService randomNumberService, IUserInterface ui)
        {
            _randomNumberService = randomNumberService;
            _ui = ui;
        }

        public void StartGame()
        {
            _ui.DisplayMessage($"Yo, Rick! Lets play some fricking game! I hide ur GUN in one of these {GameConfigurator.BoxesCount} boxes."); // morty.WELCOME_MESSAGE;

            int boxWithGun = this.RequestNumber(GameConfigurator.BoxesCount);
            // morty.HideGunInBox(boxWithGun);

            _ui.DisplayMessage($"Ha-ha! I hid ur fricking GUN! Now, let's see if u can find it! Your guess [0; {GameConfigurator.BoxesCount})?");
            // morty.ASK_FOR_GUESS_MESSAGE;

            rickGuess = _ui.GetNumber(GameConfigurator.BoxesCount);

            // morty.SetRickGuess(rickGuess);
            // morty.PlayRound();
            // all code below should be in morty.PlayRound() method

            _ui.DisplayMessage("Well, let's generate another random number.. I mean, select a box to keep in game..");
            int boxKeepInGame = this.RequestNumber(GameConfigurator.BoxesCount - 1);

            var boxesInGame = PickBoxes(GameConfigurator.BoxesCount, rickGuess, boxWithGun, boxKeepInGame);

            _ui.DisplayMessage($"Well, I'm keeping chosen box (it's {rickGuess}, remember?) and box {boxesInGame[1]}.");

            // Morty calls switching method
            SwitchingBox(boxesInGame[1]);
        }

        public void SwitchingBox(int alternativeBox)
        {
            this.isSwitching = _ui.YesNoQuestion("Do u want to switch ur box?"); // morty.SWITCHING_QUESTION;

            if (this.isSwitching)
            {
                _ui.DisplayMessage($"Ok, Rick. U switched ur box to {alternativeBox}");
            }
            else
            {
                _ui.DisplayMessage($"Ok, Rick. U kept ur box {rickGuess}");
            }
        }

        public int RequestNumber(int n)
        {
            (int mortyKey, string hmac, byte[] secretKey) = this._randomNumberService.GetMortyNum(GameConfigurator.BoxesCount);

            _ui.DisplayMessage($"HMAC{this._roundGenerations.Count+1}={hmac}");
            _ui.DisplayMessage($"Enter your number [0; {n}), Rick. Oh, and don't blame me in cheating, though!");
            int rickKey = _ui.GetNumber(n);

            int result = this._randomNumberService.GetResultNumber(mortyKey, rickKey, n);

            _roundGenerations.Add(new GenerationRevealDTO
            {
                MortyNumber = mortyKey,
                RickNumber = rickKey,
                SecretKey = secretKey,
                ResultNumber = result
            });

            return result;
        }

        public static int[] PickBoxes(int N, int rickChoice, int gunBox, int mortyNum)
        {
            if (rickChoice == gunBox)
            {
                var remaining = Enumerable.Range(0, N)
                                    .Where(i => i != rickChoice)
                                    .ToList();

                int secondBox = remaining[mortyNum];
                return new[] { rickChoice, secondBox };
            }
            else
            {
                return new[] { rickChoice, gunBox };
            }
        }
    }
}