public class Match{
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