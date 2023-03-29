using System.IO;
using System.Timers;


namespace app{
    struct Match {
        public Club homeTeam{ get; set; }
        public Club awayTeam{ get; set; }

        public int homeClubGoals{ get; set; }
        public int awayClubGoals{ get; set; }

        public Match(Club homeTeam, int homeClubGoals, Club awayTeam, int awayClubGoals){
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
            this.homeClubGoals = homeClubGoals;
            this.awayClubGoals = awayClubGoals;
        }
        

        public override string ToString()
        {
            return $"{homeTeam.abbreviation} {homeClubGoals}-{awayClubGoals} {awayTeam.abbreviation}";
        }
    }
    class Program{
        static List<League>? leagueList = new List<League>();
        static List<Club> clubs = new List<Club>();
        static League? superliga;
        static League? upperSuperliga;
        static League? lowerSuperliga;
        static string filepath = "Files/results.txt";
        static void Main(){
            initiateClubs();
            //initiateTestClubs("R22SortingTest");
            //initiateTestClubs("R22SortingTestEqualPoints");
            initiateLeague();
            
            
            
            
            
            
            //Activate the method from league specificly for that one that takes the clubs-----------------
            //in that league and split it into 2 list that is returned inside one list 
            //that then is used to choose where the 2 list goes using index
            //List<List<Club>> listOfListOfClubs = superliga.preliminaryFinish();
            //upperSuperliga.clubs = listOfListOfClubs[0];
            //lowerSuperliga.clubs = listOfListOfClubs[1];
            //This need to be moved to a better plce-------------------------------------------------------

            System.Console.WriteLine("Testing----------------------------------------");

            System.Console.WriteLine("------------------------------------------------");
            //System.Console.WriteLine(superliga);
            //System.Console.WriteLine(upperSuperliga);
            //System.Console.WriteLine(lowerSuperliga);
            //List<Match> round = initiateRound("1");
            runRounds();
            //System.Console.WriteLine(superliga);
            
            //

            //runRound(round);

        }

        static void runRounds() {
            try {
                string[] files = Directory.GetFiles("Files/","round*");
                int i = 1;
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    foreach(string file in files) {
                        List<Match> round = initiateRound(i);
                        runRound(round);
                        if(i <= 22) {
                            string superligaResults = "-----------------------------------------------------------------------------\n\n" + superliga + "\n";
                            Console.WriteLine(superligaResults);
                            writer.WriteLine(superligaResults);
                        } else {
                            string upperSuperligaResults = "------------------------------------------------------------\n\n" + upperSuperliga;
                            string lowerSuperligaResults = "\n" + lowerSuperliga + "\n";
                            Console.WriteLine(upperSuperligaResults);
                            writer.WriteLine(upperSuperligaResults);
                            Console.WriteLine(lowerSuperligaResults);
                            writer.WriteLine(lowerSuperligaResults);
                        }
                        i++;
                        Thread.Sleep(1000);
                    }
                }
            } catch (Exception e) {
                Console.WriteLine("Process failed: " + e.ToString());
            }
        }

        static void runRound(List<Match> matches){
            foreach(Match match in matches){
                string HTAbbreviation = match.homeTeam.abbreviation;
                string ATAbbreviation = match.awayTeam.abbreviation;
                Club homeClub = findClub(HTAbbreviation);
                Club awayClub = findClub(ATAbbreviation);
                homeClub.gamesPlayed += 1;
                homeClub.goalsFor += match.homeClubGoals;
                homeClub.goalsAgainst += match.awayClubGoals;
                homeClub.goalDifference = homeClub.goalsFor - homeClub.goalsAgainst;
                awayClub.gamesPlayed += 1;
                awayClub.goalsFor += match.awayClubGoals;
                awayClub.goalsAgainst += match.homeClubGoals;
                awayClub.goalDifference = awayClub.goalsFor - awayClub.goalsAgainst;
                if(match.homeClubGoals == match.awayClubGoals){
                    homeClub.gamesDrawn++;
                    homeClub.points++;
                    homeClub.streakSet("D");
                    awayClub.gamesDrawn++;
                    awayClub.points++;
                    awayClub.streakSet("D");
                }
                else if(match.homeClubGoals > match.awayClubGoals){
                    homeClub.gamesWon++;
                    homeClub.points += 3;
                    homeClub.streakSet("W");
                    awayClub.gamesLost++;
                    awayClub.streakSet("L");
                }
                else{
                    homeClub.gamesLost++;
                    homeClub.streakSet("L");
                    awayClub.gamesWon++;
                    awayClub.points += 3;
                    awayClub.streakSet("W");
                }
                //Implement update of all data neccesary
            }
        }

        static List<Match> initiateRound(int round){
            List<Match> matches = new List<Match>();
            StreamReader reader = new StreamReader("Files/round-" + round + ".csv");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');
                Match tempMatch = getMatch(values);
                matches.Add(tempMatch);
            }
            reader.Close();
            return matches;
        }

        static Match getMatch(string[] matchStats){
            Club homeClub = findClub(matchStats[0].ToUpper());
            Club awayClub = findClub(matchStats[1].ToUpper());
            int homeGoals = Int32.Parse(matchStats[2].Split("-")[0]);
            int awayGoals = Int32.Parse(matchStats[2].Split("-")[1]);
            Match match = new Match(homeClub, homeGoals, awayClub, awayGoals);
            return match;
        }
        
        static Club findClub(string abbreviation){
            Club foundClub = null;
            foreach(Club club in clubs){
                if(club.abbreviation == abbreviation){
                    foundClub = club;
                }
            }

            return foundClub;
        }

        static void initiateLeague(){
            try{
                StreamReader reader = new StreamReader("Files/setup.csv");
                bool isFirstRow = true;
                List<Club> listOfClubs = new List<Club>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (isFirstRow) // check if this is the first row
                    {
                        isFirstRow = false; // set the flag to false for all subsequent rows
                        continue; // skip processing the first row
                    }

                    string[] values = line.Split(';');
                    LeagueType type = values[7] == "preSplitUp" ? LeagueType.PRESPLITUP : LeagueType.POSTSPLITUP;
                    League temp = new League(
                        type,
                        values[0], 
                        Int32.Parse(values[1]), 
                        Int32.Parse(values[2]), 
                        Int32.Parse(values[3]), 
                        Int32.Parse(values[4]), 
                        Int32.Parse(values[5]), 
                        Int32.Parse(values[6]), 
                        listOfClubs
                        );
                    leagueList.Add(temp);
                }
                reader.Close();


                //Assign each leage to their global variable
                superliga = leagueList[0];
                upperSuperliga = leagueList[1];
                lowerSuperliga = leagueList[2];
                //Assign the clubs to the preliminary league.
                superliga.clubs = clubs;
            }catch(Exception e){
                System.Console.WriteLine("Setup File not found");
            }
            
        }


        static void initiateClubs(){
            try{
                StreamReader reader = new StreamReader("Files/teams.csv");
                bool isFirstRow = true;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (isFirstRow) // check if this is the first row
                    {
                        isFirstRow = false; // set the flag to false for all subsequent rows
                        continue; // skip processing the first row
                    }

                    string[] values = line.Split(';');
                    Club tempClub = addClub(values);
                    clubs.Add(tempClub);
                }
                reader.Close();
            }catch(Exception e){
                System.Console.WriteLine("Club File not found");
            }
            
        }



        private static Club addClub(String[] clubdata){

        

            int position = 0;
            String abbreviation = clubdata[0];
            String name = clubdata[1];
            int gamesPlayed = 0;
            int gamesWon = 0;
            int gamesDrawn = 0;
            int gamesLost = 0;
            int goalsFor = 0;
            int goalsAgainst = 0;
            int goalDifference = 0; 
            int points = 0; 
            String streak = "";

            Club club = new Club(
                    position, 
                    abbreviation, 
                    name, 
                    gamesPlayed, 
                    gamesWon, 
                    gamesDrawn, 
                    gamesLost, 
                    goalsFor, 
                    goalsAgainst, 
                    goalDifference, 
                    points, 
                    streak
                    );

            return club;
        }
        static void initiateTestClubs(string file){
            StreamReader readerTest = new StreamReader("test/" + file + ".csv");
            bool isFirstRow = true;
            while (!readerTest.EndOfStream)
            {
                string line = readerTest.ReadLine();
                if (isFirstRow) // check if this is the first row
                {
                    isFirstRow = false; // set the flag to false for all subsequent rows
                    continue; // skip processing the first row
                }
                //System.Console.WriteLine(line);
                string[] values = line.Split(';');
                int position = 0;
                String abbreviation = values[1];
                String name = values[2];
                int gamesPlayed = Int32.Parse(values[3]);
                int gamesWon = Int32.Parse(values[4]);
                int gamesDrawn = Int32.Parse(values[5]);
                int gamesLost = Int32.Parse(values[6]);
                int goalsFor = Int32.Parse(values[7]);
                int goalsAgainst = Int32.Parse(values[8]);
                int goalDifference = Int32.Parse(values[9]);
                int points = Int32.Parse(values[10]);
                String streak = values[11];

                Club tempClub = new Club(
                        position, 
                        abbreviation, 
                        name, 
                        gamesPlayed, 
                        gamesWon, 
                        gamesDrawn, 
                        gamesLost, 
                        goalsFor, 
                        goalsAgainst, 
                        goalDifference, 
                        points, 
                        streak
                        );

                clubs.Add(tempClub);
            }
            readerTest.Close();
        }

    }


    
}



  
    




