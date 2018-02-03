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

        int trackCurrentCoach = -1;
        List<Coach> coachesDrafting = new List<Coach>();
        List<Player> availablePlayers = new List<Player>();

        Player[] allPlayers = new Player[40];

        string[,] names = new string[,]
        {
        /*1*/    {/*1*/"Mason Rudolph", /*2*/"Lamar Jackson", /*3*/"Josh Rosen", /*4*/"Sam Darnold", /*5*/"Baker Mayfield"},
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
        /*6*/    "Tight End", 
        /*7*/    "Line Backer", 
        /*8*/    "Offensive Tackle"
        };

        int[] ranks = new int[]
        {1 ,2 ,3 ,4 ,5 };

        //BEGIN PROGRAM
        public void InitializePlayers()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 5; column++)
                {

                    Player player = new Player(names[row, column], colleges[row, column], salaries[row, column], positions[row], ranks[column]);
                    availablePlayers.Add(player);
                    availablePlayers.CopyTo(allPlayers);
                }
            }
        }
        public void Draft()
        {
            bool exitDraft = false;
            while (!exitDraft)
            {
                Console.Clear();
                string userInput = HouseKeeping();

                bool exitHouseKeepingLoop = false;
                while (!exitHouseKeepingLoop)
                {
                    if (userInput == "Y" || userInput == "N")
                    {
                        exitHouseKeepingLoop = true;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid input.");
                        Console.WriteLine("Please enter 'Y' or 'N'.");
                        userInput = Console.ReadLine().ToUpper();
                    }
                }
                if (userInput == "N")
                {
                    exitDraft = true;
                    continue;
                }
                Console.Clear();

                Coach currentCoach = NewCoach();
                coachesDrafting.Add(currentCoach);
                trackCurrentCoach++;
                Console.Clear();

                bool exitChoosePlayer = false;

                DisplayTable();

                while (!exitChoosePlayer)
                {
                    bool exitFilterPosition = false;

                    string chosenPlayer = ChoosePlayer();

                    if (Int32.TryParse(chosenPlayer, out int playerID))
                    {

                        if (0 < playerID && playerID < 41)
                        {
                            playerID--;

                            if (availablePlayers.Contains(allPlayers[playerID]))
                            {
                                if (allPlayers[playerID].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                                {
                                    Console.WriteLine("\nYou cannot afford that player!");
                                    Console.WriteLine("Please select a valid player.\n");
                                    exitFilterPosition = true;
                                }
                                else
                                {
                                    availablePlayers.Remove(allPlayers[playerID]);
                                    coachesDrafting[trackCurrentCoach].draftedPlayers.Add(allPlayers[playerID]);

                                    coachesDrafting[trackCurrentCoach].budgetRemaining = coachesDrafting[trackCurrentCoach].budgetRemaining - allPlayers[playerID].playerSalary;

                                    Console.Clear();

                                    Console.WriteLine("You selected the following player for the {0}.\n", coachesDrafting[trackCurrentCoach].coachTeam);
                                    Console.WriteLine("Name: {0}", allPlayers[playerID].playerName);
                                    Console.WriteLine("Position: {0}", allPlayers[playerID].playerPosition);
                                    Console.WriteLine("College: {0}", allPlayers[playerID].playerCollege);
                                    Console.WriteLine("Salary: {0}\n", String.Format("{0:c}", allPlayers[playerID].playerSalary));

                                    CheckForOptimalDraft();

                                    DisplayBudget();
                                    Console.WriteLine("\nWould you like to select another player? (Y/N)");
                                    string selectAnotherPlayer = Console.ReadLine().ToUpper();

                                    Console.Clear();
                                    DisplayTable();

                                    exitChoosePlayer = CheckEndDraft();
                                    exitChoosePlayer = CheckEndTeamDraft();
                                    exitDraft = CheckEndDraft();

                                    while (selectAnotherPlayer != "Y" && selectAnotherPlayer != "N")
                                    {
                                        Console.WriteLine("That is not a valid input.");
                                        Console.WriteLine("Please enter 'Y' or 'N'.");
                                        selectAnotherPlayer = Console.ReadLine().ToUpper();
                                    }
                                    if (selectAnotherPlayer == "Y")
                                    {
                                        exitFilterPosition = true;
                                    }
                                    else
                                    {
                                        exitChoosePlayer = true;
                                        exitFilterPosition = true;
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine("\nThat player has already been drafted!");
                                Console.WriteLine("Please select a valid player.\n");
                                exitFilterPosition = true;
                            }
                        }
                        else if (playerID == 0)
                        {

                        }
                        else if (playerID == 41)
                        {
                            exitFilterPosition = true;
                            exitChoosePlayer = true;
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid input.");
                            Console.WriteLine("Please enter a valid player ID or 0\n");
                            exitFilterPosition = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid input.");
                        Console.WriteLine("Please enter a valid player ID or 0\n");
                        exitFilterPosition = true;
                    }

                    while (!exitFilterPosition)
                    {
                        string chosenPosition = FilterPosition().ToUpper();
                        if (chosenPosition == "QB" ||
                            chosenPosition == "RB" ||
                            chosenPosition == "WR" ||
                            chosenPosition == "DL" ||
                            chosenPosition == "DB" ||
                            chosenPosition == "TE" ||
                            chosenPosition == "LB" ||
                            chosenPosition == "OT")
                        {
                            Console.Clear();
                            WriteDivider();
                            DisplayPosition(chosenPosition);
                            WriteDivider();
                            exitFilterPosition = true;

                        }
                        else
                        {
                            Console.WriteLine("That is not a valid input.");
                            Console.WriteLine("Please enter a valid position.");
                        }
                    }
                }
            }
            Console.Clear();
            DisplayTeamPicks();
        }

        private string HouseKeeping()
        {
            Console.WriteLine("Welcome to the NFL draft.\n");
            Console.WriteLine("You are able to draft up to 5 players, but you have a budget of only $95 million dollars.");
            Console.WriteLine("Would you like to begin the draft? (Y/N)");
            string userInput = Console.ReadLine().ToUpper();
            return userInput;
        }
        
        private Coach NewCoach()
        {
            Console.WriteLine("Which team are you drafting for?");
            string team = Console.ReadLine();

            Coach coach = new Coach(team);
            return coach;
        }

        private void DisplayTable()
        {
            Console.WriteLine("Below is a list of all draftable players: \n");
            WriteDivider();

            WriteRankHeader();
            WriteDivider();

            DisplayPosition("QB");
            WriteDivider();

            DisplayPosition("RB");
            WriteDivider();

            DisplayPosition("WR");
            WriteDivider();

            DisplayPosition("DL");
            WriteDivider();

            DisplayPosition("DB");
            WriteDivider();

            DisplayPosition("TE");
            WriteDivider();

            DisplayPosition("LB");
            WriteDivider();

            DisplayPosition("OT");
            WriteDivider();
        }

        private void WriteDivider()
        {
            Console.WriteLine(new string('-', 145));
        }

        private void WriteRankHeader()
        {
            Console.WriteLine(String.Format("{0, -20}{1, -25}{2, -25}{3, -25}{4, -25}{5, -25}", 
                "Position", "1st Best", "2nd Best", "3rd Best", "4th Best", "5th Best"));
        }

        private string FilterPosition()
        {
            Console.Clear();
            Console.WriteLine("Choose a specific position by typing an acronym corresponding to the position.\n");
            Console.WriteLine("Quarterbacks: (QB)");
            Console.WriteLine("Running Backs: (RB)");
            Console.WriteLine("Wide-Recievers: (WR)");
            Console.WriteLine("Defensive Linemans: (DL)");
            Console.WriteLine("Defensive-Backs: (DB)");
            Console.WriteLine("Tight Endss: (TE)");
            Console.WriteLine("Line-Backers: (LB)");
            Console.WriteLine("Offensive Tackles: (OT)\n");
            return Console.ReadLine();
        }

        private void DisplayPosition(string chosenPosition)
        {
            if (chosenPosition == "QB")
            {
                Console.Write(String.Format("{0, -20}", "Quarterback"));
                for (int name = 0; name < 5; name++)
                {
                    if (availablePlayers.Contains(allPlayers[name]))
                    {
                        if (allPlayers[name].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("({0}){1, -22}", name + 1, allPlayers[name].playerName));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int college = 0; college < 5; college++)
                {
                    if (availablePlayers.Contains(allPlayers[college]))
                    {
                        if (allPlayers[college].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("{0, -25}", allPlayers[college].playerCollege));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int salary = 0; salary < 5; salary++)
                {
                    if (availablePlayers.Contains(allPlayers[salary]))
                    {
                        if (allPlayers[salary].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    string salaryString = String.Format("{0:c}", allPlayers[salary].playerSalary);
                    Console.Write(String.Format("{0, -25}", salaryString));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();
            }
            if (chosenPosition == "RB")
            {
                Console.Write(String.Format("{0, -20}", "Running Back"));
                for (int name = 5; name < 10; name++)
                {
                    if (availablePlayers.Contains(allPlayers[name]))
                    {
                        if (allPlayers[name].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("({0}){1, -22}", name + 1, allPlayers[name].playerName));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int college = 5; college < 10; college++)
                {
                    if (availablePlayers.Contains(allPlayers[college]))
                    {
                        if (allPlayers[college].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("{0, -25}", allPlayers[college].playerCollege));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int salary = 5; salary < 10; salary++)
                {
                    if (availablePlayers.Contains(allPlayers[salary]))
                    {
                        if (allPlayers[salary].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    string salaryString = String.Format("{0:c}", allPlayers[salary].playerSalary);
                    Console.Write(String.Format("{0, -25}", salaryString));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();
            }
            if (chosenPosition == "WR")
            {
                Console.Write(String.Format("{0, -20}", "Wide-Reciever"));
                for (int name = 10; name < 15; name++)
                {
                    if (availablePlayers.Contains(allPlayers[name]))
                    {
                        if (allPlayers[name].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("({0}){1, -21}", name + 1, allPlayers[name].playerName));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int college = 10; college < 15; college++)
                {
                    if (availablePlayers.Contains(allPlayers[college]))
                    {
                        if (allPlayers[college].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("{0, -25}", allPlayers[college].playerCollege));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int salary = 10; salary < 15; salary++)
                {
                    if (availablePlayers.Contains(allPlayers[salary]))
                    {
                        if (allPlayers[salary].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    string salaryString = String.Format("{0:c}", allPlayers[salary].playerSalary);
                    Console.Write(String.Format("{0, -25}", salaryString));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();
            }
            if (chosenPosition == "DL")
            {
                Console.Write(String.Format("{0, -20}", "Defensive Lineman"));
                for (int name = 15; name < 20; name++)
                {
                    if (availablePlayers.Contains(allPlayers[name]))
                    {
                        if (allPlayers[name].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("({0}){1, -21}", name + 1, allPlayers[name].playerName));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int college = 15; college < 20; college++)
                {
                    if (availablePlayers.Contains(allPlayers[college]))
                    {
                        if (allPlayers[college].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("{0, -25}", allPlayers[college].playerCollege));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int salary = 15; salary < 20; salary++)
                {
                    if (availablePlayers.Contains(allPlayers[salary]))
                    {
                        if (allPlayers[salary].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    string salaryString = String.Format("{0:c}", allPlayers[salary].playerSalary);
                    Console.Write(String.Format("{0, -25}", salaryString));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();
            }
            if (chosenPosition == "DB")
            {
                Console.Write(String.Format("{0, -20}", "Defensive-Back"));
                for (int name = 20; name < 25; name++)
                {
                    if (availablePlayers.Contains(allPlayers[name]))
                    {
                        if (allPlayers[name].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("({0}){1, -21}", name + 1, allPlayers[name].playerName));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int college = 20; college < 25; college++)
                {
                    if (availablePlayers.Contains(allPlayers[college]))
                    {
                        if (allPlayers[college].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("{0, -25}", allPlayers[college].playerCollege));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int salary = 20; salary < 25; salary++)
                {
                    if (availablePlayers.Contains(allPlayers[salary]))
                    {
                        if (allPlayers[salary].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    string salaryString = String.Format("{0:c}", allPlayers[salary].playerSalary);
                    Console.Write(String.Format("{0, -25}", salaryString));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();
            }
            if (chosenPosition == "TE")
            {
                Console.Write(String.Format("{0, -20}", "Tight End"));
                for (int name = 25; name < 30; name++)
                {
                    if (availablePlayers.Contains(allPlayers[name]))
                    {
                        if (allPlayers[name].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("({0}){1, -21}", name + 1, allPlayers[name].playerName));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int college = 25; college < 30; college++)
                {
                    if (availablePlayers.Contains(allPlayers[college]))
                    {
                        if (allPlayers[college].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("{0, -25}", allPlayers[college].playerCollege));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int salary = 25; salary < 30; salary++)
                {
                    if (availablePlayers.Contains(allPlayers[salary]))
                    {
                        if (allPlayers[salary].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    string salaryString = String.Format("{0:c}", allPlayers[salary].playerSalary);
                    Console.Write(String.Format("{0, -25}", salaryString));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();
            }
            if (chosenPosition == "LB")
            {
                Console.Write(String.Format("{0, -20}", "Line-Backer"));
                for (int name = 30; name < 35; name++)
                {
                    if (availablePlayers.Contains(allPlayers[name]))
                    {
                        if (allPlayers[name].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("({0}){1, -21}", name + 1, allPlayers[name].playerName));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int college = 30; college < 35; college++)
                {
                    if (availablePlayers.Contains(allPlayers[college]))
                    {
                        if (allPlayers[college].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("{0, -25}", allPlayers[college].playerCollege));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int salary = 30; salary < 35; salary++)
                {
                    if (availablePlayers.Contains(allPlayers[salary]))
                    {
                        if (allPlayers[salary].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    string salaryString = String.Format("{0:c}", allPlayers[salary].playerSalary);
                    Console.Write(String.Format("{0, -25}", salaryString));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();
            }
            if (chosenPosition == "OT")
            {
                Console.Write(String.Format("{0, -20}", "Offensive Tackle"));
                for (int name = 35; name < 40; name++)
                {
                    if (availablePlayers.Contains(allPlayers[name]))
                    {
                        if (allPlayers[name].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("({0}){1, -21}", name + 1, allPlayers[name].playerName));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int college = 35; college < 40; college++)
                {
                    if (availablePlayers.Contains(allPlayers[college]))
                    {
                        if (allPlayers[college].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(String.Format("{0, -25}", allPlayers[college].playerCollege));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();

                Console.Write(String.Format("{0, -20}", ""));
                for (int salary = 35; salary < 40; salary++)
                {
                    if (availablePlayers.Contains(allPlayers[salary]))
                    {
                        if (allPlayers[salary].playerSalary > coachesDrafting[trackCurrentCoach].budgetRemaining)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    string salaryString = String.Format("{0:c}", allPlayers[salary].playerSalary);
                    Console.Write(String.Format("{0, -25}", salaryString));
                    Console.ResetColor();
                }
                Console.Write("|");
                Console.WriteLine();
            }
        }

        private string ChoosePlayer()
        {
            DisplayBudget();

            Console.WriteLine("You can draft a player by typing in the number corresponding to their name.");
            Console.WriteLine("Draftable players appear in green, chosen players appear in red, and players that cannot be afforded appear in blue.");
            Console.WriteLine("You can filter positions by first pressing '0' or choose not to select another player by entering '41'.\n");
            return Console.ReadLine();
        }

        private void CheckForOptimalDraft()
        {
            if (coachesDrafting[trackCurrentCoach].draftedPlayers.Count == 3 && coachesDrafting[trackCurrentCoach].budgetRemaining >= 30000000)
            {
                bool optimalDraft = true;

                foreach (Player player in coachesDrafting[trackCurrentCoach].draftedPlayers)
                {
                    if (player.playerRank > 3)
                    {
                        optimalDraft = false;
                    }
                }
                if (optimalDraft)
                {
                    Console.WriteLine("Those were some cost effective picks!!!!\n");
                }                
            }
        }

        private bool CheckEndTeamDraft()
        {
            if (coachesDrafting[trackCurrentCoach].draftedPlayers.Count == 5)
            {
                Console.Clear();
                Console.WriteLine("You have drafted the maximum amount of players for your team.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadLine();
                return true;
            }
            else if (coachesDrafting[trackCurrentCoach].budgetRemaining < 10000000)
            {

                Console.Clear();
                Console.WriteLine("You no longer have enough money to draft any players.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadLine();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckEndDraft()
        {
            if (availablePlayers.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("All of the players have been drafted!!!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadLine();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DisplayBudget()
        {
            string remainingBudget;
            string spentBudget;

            remainingBudget = String.Format("{0:c}", coachesDrafting[trackCurrentCoach].budgetRemaining);
            spentBudget = String.Format("{0:c}", 95000000 - coachesDrafting[trackCurrentCoach].budgetRemaining);

            Console.WriteLine("You have spent: {0}", spentBudget);
            Console.WriteLine("You have remaining: {0}\n", remainingBudget);
        }

        private void DisplayTeamPicks()
        {
            bool isEmpty = coachesDrafting.Any();
            if (!isEmpty)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Displayed is a list of the team's drafts and their remaining budgets: \n");
                
                foreach (Coach coach in coachesDrafting)
                {
                    Console.WriteLine("Team: {0}\n", coach.coachTeam);
                    Console.WriteLine("\t" + "Budget remaining: {0}", String.Format("{0:c}", coach.budgetRemaining));
                    Console.WriteLine("\t" + "Players: \n");
                    foreach (Player player in coach.draftedPlayers)
                    {
                        Console.WriteLine("\t\t" + "Name: {0}", player.playerName);
                        Console.WriteLine("\t\t" + "Position: {0}", player.playerPosition);
                        Console.WriteLine("\t\t" + "College: {0}", player.playerCollege);
                        Console.WriteLine("\t\t" + "Salary: {0}\n", String.Format("{0:c}", player.playerSalary));
                    }
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}
