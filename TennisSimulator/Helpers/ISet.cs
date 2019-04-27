namespace TennisSimulator.Helpers
{
    public interface ISet
    {
        int Winner { get; }
        string SetResult { get; }
        void UpdateWinCount(int playerId);
    }
}
