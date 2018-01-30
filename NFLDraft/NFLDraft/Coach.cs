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
        public List<string> draftedPlayers = new List<string>();
        public int budgetRemaining = 95000000;

        public int GetBudgetRemaining()
        {
            return budgetRemaining;
        }
        public void SpendBudget(int salarySpent)
        {
            budgetRemaining -= salarySpent;
        }

        public Coach(string team)
        {
            coachTeam = team;
        }
    }
}
