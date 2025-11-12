class Scorecard
{
    private ScoreRules rules;
    private int[] upperScores = new int[6];
    private int tkScore, fkScore, fhScore, ssScore, lsScore, chanceScore, yahtzeeScore;
    public Scorecard(ScoreRules rules)
    {
        this.rules = rules;
    }

    private string GetStatus(bool isUsed, bool isValid)
    {
        if (isUsed) return "Used";
        if (isValid) return "Possible";
        return "Forfeit?";
    }

    public void DisplayFullScorecard()
    {
        Console.WriteLine("----- YAHTZEE SCORECARD -----");
        Console.WriteLine("UPPER SECTION:");
        Console.WriteLine("Category | Points  | Status");

        for (int i = 1; i <= 6; i++)
        {
            int preview = rules.PreviewPointsUpper(i);
            string name = i == 1 ? "Aces" : i == 2 ? "Twos" : i == 3 ? "Threes" : i == 4 ? "Fours" : i == 5 ? "Fives" : "Sixes";
            int displayPoints;

            if (rules.GetIsUpperUsed(i))
                displayPoints = upperScores[i - 1]; // saved score
            else if (preview > 0)
                displayPoints = preview;
            else
                displayPoints = 0;

            string status = GetStatus(rules.GetIsUpperUsed(i), preview > 0);
            Console.WriteLine($"{i} - {name,-6} | {displayPoints,-7} | {status}");
        }

        // Lower section
        string tkStatus = GetStatus(rules.GetIsTKUsed(), rules.IsTKValid());
        int tkDisplay = rules.GetIsTKUsed() ? tkScore : rules.IsTKValid() ? rules.PreviewTKPoints() : 0;

        string fkStatus = GetStatus(rules.GetIsFKUsed(), rules.IsFKValid());
        int fkDisplay = rules.GetIsFKUsed() ? fkScore : rules.IsFKValid() ? rules.PreviewFKPoints() : 0;

        string fhStatus = GetStatus(rules.GetIsFHUsed(), rules.IsFHValid());
        int fhDisplay = rules.GetIsFHUsed() ? fhScore : rules.IsFHValid() ? rules.PreviewFHPoints() : 0;

        string ssStatus = GetStatus(rules.GetIsSSUsed(), rules.IsSSValid());
        int ssDisplay = rules.GetIsSSUsed() ? ssScore : rules.IsSSValid() ? rules.PreviewSSPoints() : 0;

        string lsStatus = GetStatus(rules.GetIsLSUsed(), rules.IsLSValid());
        int lsDisplay = rules.GetIsLSUsed() ? lsScore : rules.IsLSValid() ? rules.PreviewLSPoints() : 0;

        string chStatus = GetStatus(rules.GetIsChanceUsed(), rules.IsChanceAvailable());
        int chDisplay = rules.GetIsChanceUsed() ? chanceScore : rules.PreviewChancePoints();

        string yaStatus = GetStatus(rules.GetIsYahtzeeUsed(), rules.IsYahtzeeValid());
        int yaDisplay = rules.GetIsYahtzeeUsed() ? yahtzeeScore : rules.IsYahtzeeValid() ? rules.PreviewYahtzeePoints() : 0;

        Console.WriteLine("-----------------------------");
        Console.WriteLine("LOWER SECTION:");
        Console.WriteLine("Category             | Points  | Status");
        Console.WriteLine($"TK - Three of a Kind  | {tkDisplay,-7} | {tkStatus}");
        Console.WriteLine($"FK - Four of a Kind   | {fkDisplay,-7} | {fkStatus}");
        Console.WriteLine($"FH - Full House       | {fhDisplay,-7} | {fhStatus}");
        Console.WriteLine($"SS - Small Straight   | {ssDisplay,-7} | {ssStatus}");
        Console.WriteLine($"LS - Large Straight   | {lsDisplay,-7} | {lsStatus}");
        Console.WriteLine($"CH - Chance           | {chDisplay,-7} | {chStatus}");
        Console.WriteLine($"YA - Yahtzee          | {yaDisplay,-7} | {yaStatus}");
        Console.WriteLine("-----------------------------");
        //Console.WriteLine("Hint: Call SelectUpper(i) or SelectTK()/SelectFK()/SelectFH()/SelectSS()/SelectLS()/SelectChance()/SelectYahtzee() to finalize a category and show its final points.");
    }

    // Selection helpers: compute final points, attempt to mark the category used, then print the finalized value.
    public int SelectUpper(int upperValue)
    {
        int finalPoints = rules.PreviewPointsUpper(upperValue);
        if (rules.UseUpper(upperValue))
        {
            upperScores[upperValue - 1] = finalPoints;
            Console.WriteLine($"Selected Upper {upperValue}: {finalPoints} points (finalized)");
            return finalPoints;
        }
        Console.WriteLine($"Cannot select Upper {upperValue}: already used.");
        return -1;
    }

    public int SelectTK()
    {
        int finalPoints = rules.PreviewTKPoints();
        if (rules.UseTK())
        {
            tkScore = finalPoints;
            Console.WriteLine($"Selected Three of a Kind: {finalPoints} points (finalized)");
            return finalPoints;
        }
        Console.WriteLine("Cannot select Three of a Kind: already used.");
        return -1;
    }

    public int SelectFK()
    {
        int finalPoints = rules.PreviewFKPoints();
        if (rules.UseFK())
        {
            fkScore = finalPoints;
            Console.WriteLine($"Selected Four of a Kind: {finalPoints} points (finalized)");
            return finalPoints;
        }
        Console.WriteLine("Cannot select Four of a Kind: already used.");
        return -1;
    }

    public int SelectFH()
    {
        int finalPoints = rules.PreviewFHPoints();
        if (rules.UseFH())
        {
            fhScore = finalPoints;
            Console.WriteLine($"Selected Full House: {finalPoints} points (finalized)");
            return finalPoints;
        }
        Console.WriteLine("Cannot select Full House: already used.");
        return -1;
    }

    public int SelectSS()
    {
        int finalPoints = rules.PreviewSSPoints();
        if (rules.UseSS())
        {
            ssScore = finalPoints;
            Console.WriteLine($"Selected Small Straight: {finalPoints} points (finalized)");
            return finalPoints;
        }
        Console.WriteLine("Cannot select Small Straight: already used.");
        return -1;
    }

    public int SelectLS()
    {
        int finalPoints = rules.PreviewLSPoints();
        if (rules.UseLS())
        {
            lsScore = finalPoints;
            Console.WriteLine($"Selected Large Straight: {finalPoints} points (finalized)");
            return finalPoints;
        }
        Console.WriteLine("Cannot select Large Straight: already used.");
        return -1;
    }

    public int SelectChance()
    {
        int finalPoints = rules.PreviewChancePoints();
        if (rules.UseChance())
        {
            chanceScore = finalPoints;
            Console.WriteLine($"Selected Chance: {finalPoints} points (finalized)");
            return finalPoints;
        }
        Console.WriteLine("Cannot select Chance: already used.");
        return -1;
    }

    public int SelectYahtzee()
    {
        int finalPoints = rules.PreviewYahtzeePoints();
        if (rules.UseYahtzee())
        {
            yahtzeeScore = finalPoints;
            Console.WriteLine($"Selected Yahtzee: {finalPoints} points (finalized)");
            return finalPoints;
        }
        Console.WriteLine("Cannot select Yahtzee: already used.");
        return -1;
    }
}