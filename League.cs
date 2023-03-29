public class League{
    public String? name{ get; set; }
    public int UCLPositions{ get; set; }
    public int UELPositions{ get; set; }
    public int UECLPositions{ get; set; }
    public int relegationSpots{ get; set; }

    public List<Club>? clubs{ get; set; }

    public League(String name, int UCLPositions, int UELPositions, int UECLPositions, int relegationSpots, List<Club> clubs){
        this.name = name;
        this.UCLPositions = UCLPositions;
        this.UELPositions = UELPositions;
        this.UECLPositions = UECLPositions;
        this.relegationSpots = relegationSpots;
        this.clubs = clubs;
    }

    private IOrderedEnumerable<Club> getTeamsSorted(){
        
        var sortedClubs = clubs
            .OrderByDescending(c => c.points)
            .ThenByDescending(c => c.goalDifference)
            .ThenByDescending(c => c.goalsFor)
            .ThenBy(c => c.name);
        
        int position = 1;
        Club tempClub = null;
        foreach(Club club in sortedClubs){
            club.position = position;
            if(tempClub != null){
                bool pointsIsSame = club.points == tempClub.points;
                bool goalDifIsSame = club.goalDifference == tempClub.goalDifference;
                bool goalsForIsSame = club.goalsFor == tempClub.goalsFor;

                if(pointsIsSame && goalDifIsSame && goalsForIsSame){
                    club.position = 100;
                }
            }
            position++;
            tempClub = club;
        }
        return sortedClubs;
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
        IOrderedEnumerable<Club> sortedClubs =  getTeamsSorted();
        foreach (Club club in sortedClubs){
            String pos = club.position == 100? "-" : club.position.ToString();
            returnString += "\n"+string.Format(formatter(), 
                         pos, club.abbreviation, club.name, club.gamesPlayed, club.gamesWon, club.gamesDrawn, club.gamesLost, club.goalsFor, 
                         club.goalsAgainst, club.goalDifference, club.points, club.streak);
        }

        
        return returnString;
    }

}