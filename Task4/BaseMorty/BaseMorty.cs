using Task4.GameCore;
using Task4.UserInteractions;
using System.Text.Json;

namespace Task4.Morty;

public abstract class BaseMorty
{
    public MortyMessages Messages = new MortyMessages(
        "Yo, Rick! Lets play some fricking game!",
        "Ha-ha! I hid ur fricking GUN! Now, let's see if u can find it!",
        "Do u want to switch ur box?",
        "Damn, Rick! U win this time... Well-well, take ur useless gun..",
        "Nah, Rick! I win! Now lets find a better usage for this GUN! Ahhahah!",
        "Wanna play one more round?",
        "Ok, Rick. See u later!",
        "Well, lets play again!"
    );

    public abstract float WinRateStayed { get; }
    public abstract float WinRateSwitched { get; }

    protected IGameContext? gameContext;
    protected IUserInterface? ui;

    protected int boxWithGun;
    protected int rickGuess;
    protected int boxesCount;

    public bool IsInitialized => gameContext != null && ui != null && boxesCount > 0;

    public virtual void HideGunInBox(int boxWithGun)
    {
        this.boxWithGun = boxWithGun;
    }

    public virtual void SetRickGuess(int rickGuess)
    {
        this.rickGuess = rickGuess;
    }

    public virtual void Init(IGameContext gameContext, IUserInterface ui, int boxesCount)
    {
        this.gameContext = gameContext;
        this.ui = ui;
        this.boxesCount = boxesCount;
    }

    public abstract void PlayRound();

    protected void LoadDialogs(string filePath)
    {
        try
        {
            var dialogs = JsonSerializer.Deserialize<MortyMessages>(File.ReadAllText(filePath));

            if (dialogs is not null)
            {
                this.Messages = dialogs;
            }
        }
        catch (FileNotFoundException)
        {
            this.ui!.DisplayMessage($"Hm... I can't find my notes here.. {filePath}");
            this.ui!.DisplayMessage($"However, lets continue!");
        }
    }

    protected int[] PickBoxes(int N, int rickChoice, int gunBox, int pickedBox)
    {
        if (rickChoice == gunBox)
        {
            var remaining = Enumerable.Range(0, N)
                                .Where(i => i != rickChoice)
                                .ToList();

            int secondBox = remaining[pickedBox];
            return new[] { rickChoice, secondBox };
        }
        else
        {
            return new[] { rickChoice, gunBox };
        }
    }
}