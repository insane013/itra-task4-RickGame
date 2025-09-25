namespace Task4.GameCore
{
    public interface IGameContext
    {
        public void StartGame();
        public void SwitchingBox(int alternativeBox);
        public int RequestNumber(int n);
        public void EndRound();
        public void Reveal();
        public void ComputeResults();
        public void RestartRound();
    }
}