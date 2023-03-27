public class League{
    private String? name;
    private int UCLPositions;
    private int UELPositions;
    private int UECLPositions;
    private int relegationSpots;

    private List<Club>? clubs;

    public League(String name, int UCLPositions, int UELPositions, int UECLPositions, int relegationSpots, List<Club> clubs){
        this.name = name;
        this.UCLPositions = UCLPositions;
        this.UELPositions = UELPositions;
        this.UECLPositions = UECLPositions;
        this.relegationSpots = relegationSpots;
        this.clubs = clubs;
    }

    private void sortTeams(){
        //Skal implementeres
    }

    
    public override String ToString(){

        String returnString = "Name: " + this.name + "\n";

        //Adding the header for the table so it looks clean
        returnString += string.Format("{0,-5} {1,-5} {2,-30} {3,-3} {4,-3} {5,-3} {6,-3} {7,-3} {8,-3} {9,-3} {10,-3} {11,-10}",
                            "Pos", "abr", "Club Name", "G", "W", "D", "L", "G+", "G-", "GD", "P", "Streak");

        //Sorting the teams by points etc. then adding them to the tostring in the same format as the header.
        sortTeams();
        foreach (Club club in clubs){
            returnString += "\n" + club;
        }

        
        return returnString;
    }

}