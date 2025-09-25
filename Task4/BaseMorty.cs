using Task4.GameCore;
using Task4.UserInteractions;

namespace Task4;

public abstract class BaseMorty
{
    public Dictionary<string, string> Messages = new Dictionary<string, string>()
    {
        { "WELCOME_MESSAGE", "Yo, Rick! Lets play some fricking game!" },
        { "ASK_FOR_GUESS_MESSAGE", "Ha-ha! I hid ur fricking GUN! Now, let's see if u can find it!" },
        { "SWITCHING_QUESTION", "Do u want to switch ur box?" },
        { "RICK_WIN_MESSAGE", "Damn, Rick! U win this time... Well-well, take ur useless gun.." },
        { "RICK_LOSE_MESSAGE", "Nah, Rick! I win! Now lets find a better usage for this GUN! Ahhahah!" },
        { "PLAY_AGAIN_QUESTION", "Wanna play one more round?" },
        { "GOODBYE_MESSAGE", "Ok, Rick. See u later!" }
    };

    protected IGameContext? gameContext;
    protected IUserInterface? ui;

    protected int boxWithGun;
    protected int rickGuess;
    protected int boxesCount;

    public bool IsInitialized => gameContext != null && ui != null && boxesCount > 0;

    public abstract void HideGunInBox(int boxWithGun);

    public abstract void SetRickGuess(int rickGuess);

    public abstract void Init(IGameContext gameContext, IUserInterface ui, int boxesCount);

    public abstract void PlayRound();

    public abstract int[] PickBoxes(int boxesCount, int rickGuess, int boxWithGun, int boxKeepInGame);
}