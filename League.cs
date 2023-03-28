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

    
    public override String ToString(){

        String returnString = "Name: " + this.name + "\n";

        //Adding the header for the table so it looks clean
        returnString += string.Format("{0,-5} {1,-5} {2,-30} {3,-3} {4,-3} {5,-3} {6,-3} {7,-3} {8,-3} {9,-3} {10,-3} {11,-10}",
                            "Pos", "abr", "Club Name", "G", "W", "D", "L", "G+", "G-", "GD", "P", "Streak");

        //Sorting the teams by points etc. then adding them to the tostring in the same format as the header.
        IOrderedEnumerable<Club> sortedClubs =  getTeamsSorted();
        foreach (Club club in sortedClubs){
            returnString += "\n" + club;
        }

        
        return returnString;
    }

}