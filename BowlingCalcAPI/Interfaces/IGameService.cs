using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingCalcAPI.Interfaces
{
    public interface IGameService
    {
        int CalculateScore(string[] pinsDowned);
    }
}
