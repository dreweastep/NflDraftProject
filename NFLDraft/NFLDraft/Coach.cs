using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDraft
{
    public class Coach
    {
        //DECLARATIONS
        public string coachTeam { get; }
        public List<Player> draftedPlayers = new List<Player>();
        public int budgetRemaining { get; set; } = 95000000;
        
        public Coach(string team)
        {
            coachTeam = team;
        }
    }
}
