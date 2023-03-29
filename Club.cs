public class Club{

    public int position{ get; set; }
    public string abbreviation{ get; set; }
    public string name{ get; set;}
    public int gamesPlayed{ get; set;}
    public int gamesWon{ get; set;}
    public int gamesDrawn{ get; set;}
    public int gamesLost{ get; set;}
    public int goalsFor{ get; set;}
    public int goalsAgainst{ get; set;}
    public int goalDifference{ get; set;}
    public int points{ get; set;}
    public string streak{ get; set;}
    public void streakSet(string InputResult = ""){
        if(InputResult.Length != 1){
            System.Console.WriteLine("This is an invalid length for the format of the Streak counter");
        }else{
            if(streak.Length >= 5){
                streak = streak.Substring(1);
                streak = streak + InputResult;
            }else{
                streak = streak + InputResult;
            }
            this.streak = streak;
        }
    }

     public Club(int position, string abbreviation, string name, int gamesPlayed, int gamesWon, int gamesDrawn, 
                int gamesLost, int goalsFor, int goalsAgainst, int goalDifference, int points, string streak = "") {

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
}