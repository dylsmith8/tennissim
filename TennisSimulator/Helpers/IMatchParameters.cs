using System.Collections.Generic;

namespace TennisSimulator.Helpers
{
    public interface IMatchParameters
    {
        int GetRandomScorer();
        List<ISet> InitialiseMatchSets();
    }
}
