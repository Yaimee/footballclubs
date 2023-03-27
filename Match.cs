public class Match{
    private Club homeTeam;
    private Club awayTeam;

    private int homeClubGoals;
    private int awayClubGoals;

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