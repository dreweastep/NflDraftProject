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
        public string playerPosition { get; }
        public int playerSalary { get; }
        public bool isDrafted = false;

        public bool GetIsDrafted()
        {
            return isDrafted;
        }

        public void SetIsDrafted()
        {
            isDrafted = true;
        }
        public Player(string name, string college, string position, int salary)
        {
            playerName = name;
            playerCollege = college;
            playerPosition = position;
            playerSalary = salary;
        }
    }
}
