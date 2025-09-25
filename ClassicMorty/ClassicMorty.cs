using Task4;
using Task4.GameCore;
using Task4.UserInteractions;

namespace ClassicMorty;

public class ClassicMorty : BaseMorty
{
    public override void HideGunInBox(int boxWithGun)
    {
        this.boxWithGun = boxWithGun;
    }

    public override void SetRickGuess(int rickGuess)
    {
        this.rickGuess = rickGuess;
    }

    public override void Init(IGameContext gameContext, IUserInterface ui, int boxesCount)
    {
        this.gameContext = gameContext;
        this.ui = ui;
        this.boxesCount = boxesCount;
    }

    public override void PlayRound()
    {
        if (!this.IsInitialized)
        {
            Console.WriteLine("Morty is not initialized properly... Did u forget to call Init() method?");
            throw new InvalidOperationException("Morty is not initialized properly.");
        }

        this.ui!.DisplayMessage("Well, let's generate another random number.. I mean, select a box to keep in game..");

        int boxKeepInGame = this.gameContext!.RequestNumber(this.boxesCount - 1);

        var boxesInGame = PickBoxes(this.boxesCount, rickGuess, boxWithGun, boxKeepInGame);

        this.ui.DisplayMessage($"Well, I'm keeping chosen box (it's {rickGuess}, remember?) and box {boxesInGame[1]}.");

        this.gameContext.SwitchingBox(boxesInGame[1]);

        this.gameContext.EndRound();
    }
    
    public override int[] PickBoxes(int N, int rickChoice, int gunBox, int mortyNum)
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
