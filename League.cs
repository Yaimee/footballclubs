public class League{

    LeagueType leagueType;
    public String? name{ get; set; }
    public int UCLPositions{ get; set; }
    public int UELPositions{ get; set; }
    public int UECLPositions{ get; set; }
    public int relegationSpots{ get; set; }
    public int upperLeagueSpots{ get; set; }
    public int lowerLeagueSpots{ get; set; }

    public List<Club>? clubs{ get; set; }

    public League(LeagueType leagueType, String name, int UCLPositions, int UELPositions, int UECLPositions, int relegationSpots, int upperLeagueSpots, int lowerLeagueSpots, List<Club> clubs){
        this.leagueType = leagueType;
        this.name = name;
        this.UCLPositions = UCLPositions;
        this.UELPositions = UELPositions;
        this.UECLPositions = UECLPositions;
        this.relegationSpots = relegationSpots;
        this.upperLeagueSpots = upperLeagueSpots;
        this.lowerLeagueSpots = lowerLeagueSpots;
        this.clubs = clubs;
    }

    private void sortTeams(){
        clubs = clubs.OrderByDescending(c => c.points)
             .ThenByDescending(c => c.goalDifference)
             .ThenByDescending(c => c.goalsFor)
             .ThenBy(c => c.name)
             .ToList();
        
        Club tempClub = null;
        for(int i = 0; i < clubs.Count; i++){
            Club club = clubs[i];
            club.position = i + 1;
            if(tempClub != null){
                bool pointsIsSame = club.points == tempClub.points;
                bool goalDifIsSame = club.goalDifference == tempClub.goalDifference;
                bool goalsForIsSame = club.goalsFor == tempClub.goalsFor;

                if(pointsIsSame && goalDifIsSame && goalsForIsSame){
                    club.position = 100;
                }
            }
            tempClub = club;
        }
    }


    public int longestTeamName(){
        int[] arrLen = new int[12];
        int j = 0;
        foreach (Club item in clubs)
        {
            string name = item.name;
            int nameLen = name.Length;
            arrLen[j] = (nameLen);
            j++;
        }
        int Maxlength = 0;
        for (int i = 0; i < arrLen.Length; i++)
        {
            if(Maxlength<arrLen[i]){
                Maxlength = arrLen[i];
            }
        }
        
        return Maxlength;
    }
    public List<List<Club>> preliminaryFinish(){
        List<List<Club>> listOfClubs = new List<List<Club>>();
        List<Club> upperLeagueClubs = new List<Club>();
        List<Club> lowerLeagueClubs = new List<Club>();
        
        sortTeams();
        upperLeagueClubs = clubs.GetRange(0,6);
        lowerLeagueClubs = clubs.GetRange(6,6);

        listOfClubs.Add(upperLeagueClubs);
        listOfClubs.Add(lowerLeagueClubs);
        return listOfClubs;
    }
    public string formatter(){
        //{posistion, reserved Characters}
        string posFormat = "{0,-5}";
        string abrFormat = "{1,-5}";
        string clubNameFormat = "{2, -"+longestTeamName()+"}";
        string clubGames = "{3, -3}";
        string clubWins = "{4, -3}";
        string clubDraws = "{5, -3}";
        string clubLosses = "{6, -3}";
        string clubGoalsFor = "{7, -3}";
        string clubGoalsAginst = "{8, -3}";
        string clubGoalsDif = "{9, -3}";
        string clubPoints = "{10, -3}";
        string clubStreak = "{11, -3}";
        return posFormat+" "+abrFormat+" "+clubNameFormat+" "+clubGames+" "+clubWins+" "+clubDraws+" "+clubLosses+" "+clubGoalsFor+" "+clubGoalsAginst+" "+clubGoalsDif+" "+clubPoints+" "+clubStreak;
    }
    
    public override String ToString(){

        String returnString = "Name: " + this.name + "\n";
        //Adding the header for the table so it looks clean
        
        
        

        returnString += string.Format(formatter(),
                            "Pos", "abr", "Club Name", "G", "W", "D", "L", "G+", "G-", "GD", "P", "Streak");

        //Sorting the teams by points etc. then adding them to the tostring in the same format as the header.
        sortTeams();
        if(clubs.Count != null){
            foreach (Club club in clubs){
            String pos = club.position == 100? "-" : club.position.ToString();
            returnString += "\n"+string.Format(formatter(), 
                         pos, club.abbreviation, club.name, club.gamesPlayed, club.gamesWon, club.gamesDrawn, club.gamesLost, club.goalsFor, 
                         club.goalsAgainst, club.goalDifference, club.points, club.streak);
            }
        }
        

        
        return returnString;
    }

}