using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDraft
{
    class CoachPicks
    {
        //DECLARATIONS

        string[, ] playerNames = new string[,]
        {
        /*1*/    {"MasonRudolph", "Lamar Jackson", "Josh Rosen", "Sam Darnold", "Baker Mayfield"},
        /*2*/    {"Saquon Barkley", "Derrius Guice", "Bryce Love", "Ronald Jones II", "Damien Harris"},
        /*3*/    {"Courtland Sutton", "James Washington", "Marcell Ateman", "Anthony Miller", "Calvin Ridley"},
        /*4*/    {"Maurice Hurst", "Vita Vea", "Taven Bryan", "Da'Ron Payne", "Harrison Phillips"},
        /*5*/    {"Joshua Jackson", "Derwin James", "Denzel Ward", "Minkah Fitzpatrick", "Isaiah Oliver"},
        /*6*/    {"Mark Andrews", "Dallas Goedert", "Jaylen Samuels", "Mike Gesicki", "Troy Fumagall"},
        /*7*/    {"Roquan Smith", "Tremaine Edmunds", "Kendall Joseph", "Dorian O'Daniel", "Malik Jeffers"},
        /*8*/    {"Orlando Brown", "Kolton Miller", "Chukwuma Okorafor", "Connor Williams", "Mike McGlinchey"}
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

        int[,] salary = new int[,]
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

        string[] position = new string[]
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
    }
}
