public class Club{

    public int position{ get; set; }
    public String abbreviation{ get; set; }

    public String name;
    public int gamesPlayed;
    public int gamesWon;
    public int gamesDrawn;
    public int gamesLost;
    public int goalsFor;
    public int goalsAgainst;
    public int goalDifference;
    public int points;
    public String streak;

     public Club(int position, String abbreviation, String name, int gamesPlayed, int gamesWon, int gamesDrawn, 
                int gamesLost, int goalsFor, int goalsAgainst, int goalDifference, int points, String streak) {

        this.position = position;
        this.name = name;
        this.abbreviation = abbreviation;
        this.gamesPlayed = gamesPlayed;
        this.gamesWon = gamesWon;
        this.gamesDrawn = gamesDrawn;
        this.gamesLost = gamesLost;
        this.goalsFor = goalsFor;
        this.goalsAgainst = goalsAgainst;
        this.goalDifference = goalDifference;
        this.points = points;
        this.streak = streak;
    }


    public override string ToString() {
    string streakString = string.Join(", ", streak);
    return string.Format("{0,-5} {1,-5} {2,-30} {3,-3} {4,-3} {5,-3} {6,-3} {7,-3} {8,-3} {9,-3} {10,-3} {11,-10}", 
                         position, abbreviation, name, gamesPlayed, gamesWon, gamesDrawn, gamesLost, goalsFor, 
                         goalsAgainst, goalDifference, points, streakString);
}

}