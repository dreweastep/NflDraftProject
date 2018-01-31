using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDraft
{
    public class Player
    {
        //DECLARATIONS
        public string playerName { get; }
        public string playerCollege { get; }
        public int playerSalary { get; }
        public string playerPosition { get; }
        public int playerRank { get; }
        
        public Player(string name, string college, int salary, string position, int rank)
        {
            playerName = name;
            playerCollege = college;
            playerSalary = salary;
            playerPosition = position;
            playerRank = rank;
        }
    }
}
