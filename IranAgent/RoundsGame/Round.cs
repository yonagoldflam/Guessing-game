using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.RoundsGame
{
    public class Round
    {
        public int RoundId { get; set; }
        public int PlayerId { get; set; }
        public int SoldierId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int WrongAttemps { get; set; }
        public Round(int playerId, int soldierId, DateTime startTime, int wrongAttemps, int roundId = 0)
        {
            RoundId = roundId;
            PlayerId = playerId;
            SoldierId = soldierId;
            StartTime = startTime;
            WrongAttemps = wrongAttemps;
        }
    }
}
