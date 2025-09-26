using Task4.GameCore;
using Task4.UserInteractions;
using Task4.Morty;

namespace ClassicMorty;

public class ClassicMorty : BaseMorty
{
    public override float WinRateStayed => 1f / this.boxesCount;
    public override float WinRateSwitched => (this.boxesCount - 1) / (float)this.boxesCount;
    private string pathToDialogFile = @"D:\Development projects\ITRA\task4\ClassicMorty\dialogs.json";

    public override void Init(IGameContext gameContext, IUserInterface ui, int boxesCount)
    {
        base.Init(gameContext, ui, boxesCount);

        this.LoadDialogs(pathToDialogFile);
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
}
