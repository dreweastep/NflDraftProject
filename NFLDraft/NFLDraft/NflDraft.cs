using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDraft
{
    class NflDraft
    {
        //DECLARATIONS

        bool exitCondition = false;
        List<Coach> coachesDrafting = new List<Coach>();
        List<Player> availablePlayers = new List<Player>();

        string[,] names = new string[,]
        {
        /*1*/    {/*1*/"MasonRudolph", /*2*/"Lamar Jackson", /*3*/"Josh Rosen", /*4*/"Sam Darnold", /*5*/"Baker Mayfield"},
        /*2*/    {/*6*/"Saquon Barkley", /*7*/"Derrius Guice", /*8*/"Bryce Love", /*9*/"Ronald Jones II", /*10*/"Damien Harris"},
        /*3*/    {/*11*/"Courtland Sutton", /*12*/"James Washington", /*13*/"Marcell Ateman", /*14*/"Anthony Miller", /*15*/"Calvin Ridley"},
        /*4*/    {/*16*/"Maurice Hurst", /*17*/"Vita Vea", /*18*/"Taven Bryan", /*19*/"Da'Ron Payne", /*20*/"Harrison Phillips"},
        /*5*/    {/*21*/"Joshua Jackson", /*22*/"Derwin James", /*23*/"Denzel Ward", /*24*/"Minkah Fitzpatrick", /*25*/"Isaiah Oliver"},
        /*6*/    {/*26*/"Mark Andrews", /*27*/"Dallas Goedert", /*28*/"Jaylen Samuels", /*29*/"Mike Gesicki", /*30*/"Troy Fumagall"},
        /*7*/    {/*31*/"Roquan Smith", /*32*/"Tremaine Edmunds", /*33*/"Kendall Joseph", /*34*/"Dorian O'Daniel", /*35*/"Malik Jeffers"},
        /*8*/    {/*36*/"Orlando Brown", /*37*/"Kolton Miller", /*38*/"Chukwuma Okorafor", /*39*/"Connor Williams", /*40*/"Mike McGlinchey"}
        };

        string[,] colleges = new string[,]
        {
        /*1*/    {"(Oklahoma State)", "(Louisville)", "(UCLA)", "(Southern California)", "(Oklahoma)"},
        /*2*/    {"(Penn State)", "(LSU)", "(Stanford)", "(Southern California)", "(Alabama)"},
        /*3*/    {"(Southern Methodist)", "(Oklahoma State)", "(Oklahoma State)", "(Memphis)", "(Alabama)"},
        /*4*/    {"(Michigan)","(Washington)", "(Florida)", "(Alabama)", "(Stanford)"},
        /*5*/    {"(Iowa)", "(Florida State)", "(Ohio State)", "(Alabama)", "(Colorado)"},
        /*6*/    {"(Oklahoma)", "(So. Dakota State)", "(NC State)", "(Penn State)", "(Wisconsin)"},
        /*7*/    {"(Georgia)", "(Virgina Tech)", "(Clemson)", "(Clemson)", "(Texas)"},
        /*8*/    {"(Oklahoma)", "(UCLA)", "(Western Michigan)", "(Texas)","(Notre Dame)"}
        };

        int[,] salaries = new int[,]
        {
        /*1*/    {26400100, 20300100, 17420300, 13100145, 10300000},
        /*2*/    {24500100, 19890200, 18700800, 15000000, 11600400},
        /*3*/    {23400000, 21900300, 19300230, 13400230, 10000000},
        /*4*/    {26200300, 22000000, 16000000, 18000000, 13000000},
        /*5*/    {24000000, 22500249, 20000100, 16000200, 11899999},
        /*6*/    {27800900, 21000800, 17499233, 27900200, 14900333},
        /*7*/    {22900300, 19000590, 18000222, 12999999, 10000100},
        /*8*/    {23000000, 20000000, 19400000, 16200700, 15900000}

        };

        string[] positions = new string[]
        {
        /*1*/    "Quarterback", 
        /*2*/    "Running Back", 
        /*3*/    "Wide-Reciever", 
        /*4*/    "Defensive Lineman", 
        /*5*/    "Defensive-Back",
        /*6*/    "Tight Ends", 
        /*7*/    "Line Backers", 
        /*8*/    "Offensive Tackle"
        };

        int[] ranks = new int[]
        {1 ,2 ,3 ,4 ,5 };

        //BEGIN PROGRAM
        public void Draft()
        {
            InitializePlayers();
            foreach (Player player in availablePlayers)
            {
                Console.WriteLine(player.playerName);
            }
        }
        private void InitializePlayers()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 5; column++)
                {

                    Player player = new Player(names[row, column], colleges[row, column], salaries[row, column], positions[row], ranks[column]);
                    availablePlayers.Add(player);
                }
            }
        }
        private bool HouseKeeping()
        {
            return true;
        }
        private string NewCoach()
        {
            return "PLACEHOLDER";
        }
        private void DisplayTable()
        {

        }
        private string FilterPosition()
        {
            return "PLACEHOLDER";
        }
        private void DisplayPosition()
        {

        }
        private int ChoosePlayer()
        {
            return 0;
        }
        private bool CheckAvailibility()
        {
            return true;
        }
        private void ChangePlayerStatus()
        {

        }
        private bool CheckForOptimalDraft()
        {
            return true;
        }
        private int CheckBudget()
        {
            return 0;
        }
        private int ChangeTextBackground()
        {
            return 0;
        }
        private int DisplayCurrentBudget()
        {
            return 0;
        }
        private int DisplaySpentBudget()
        {
            return 0;
        }
        private void EndDraft()
        {

        }

    }
}
