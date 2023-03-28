using System.IO;


namespace app{
    class Program{

        static List<Club> clubs = new List<Club>();
        static League? superliga;
        static void Main(){
            initiateClubs();
            initiateLeague();
            System.Console.WriteLine(superliga);
            
            List<Match> round = initiateRound("1");

            foreach(Match match in round){
                System.Console.WriteLine(match);
            }
           
        }


        static void runRound(List<Match> matches){
            foreach(Match match in matches){
                
            }
        }

        static List<Match> initiateRound(String round){
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

            return foundClub;;
        }



        



        static void initiateLeague(){
            StreamReader reader = new StreamReader("Files/setup.csv");
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
                superliga = new League(
                    values[0], 
                    Int32.Parse(values[1]), 
                    Int32.Parse(values[2]), 
                    Int32.Parse(values[3]), 
                    Int32.Parse(values[4]), 
                    clubs
                    );
            }
            reader.Close();
        }


        static void initiateClubs(){
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

    }
}



  
    




