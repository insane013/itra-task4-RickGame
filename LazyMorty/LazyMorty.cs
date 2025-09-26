using System.Text.Json;
using System.Text.Json.Serialization;
using Task4;
using Task4.GameCore;
using Task4.UserInteractions;
using Task4.Morty;

namespace LazyMorty;

public class LazyMorty : BaseMorty
{
    public override float WinRateStayed => 1f / this.boxesCount;
    public override float WinRateSwitched => (this.boxesCount - 1) / (float)this.boxesCount;
    
    private string pathToDialogFile = @"D:\Development projects\ITRA\task4\LazyMorty\dialogs.json";

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

        var boxesInGame = PickBoxes(this.boxesCount, rickGuess, boxWithGun, 0);

        this.ui!.DisplayMessage($"Now u have boxes {rickGuess} and {boxesInGame[1]}.");

        this.gameContext!.SwitchingBox(boxesInGame[1]);

        this.gameContext.EndRound();
    }
}
