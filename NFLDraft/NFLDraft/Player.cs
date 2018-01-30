using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDraft
{
    public class Player
    {
        public string playerName { get; }
        public string playerCollege { get; }
        public string playerPosition { get; }
        public int playerSalary { get; }
        public bool isDrafted { get; set; }

        public Player(string name, string college, string position, int salary)
        {
            playerName = name;
            playerCollege = college;
            playerPosition = position;
            playerSalary = salary;
        }
    }
}
