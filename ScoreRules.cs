class ScoreRules()
{
    // VERY IMPORTANT IT OUTPUTS FALSE WHENEVER: (For future reference)
    // Category is already used, or if its not used + no match
    // Outputs true if not used + dice match 

    private bool usedTK = false;
    private bool usedFK = false;
    private bool usedFH = false;
    private bool usedSS = false;
    private bool usedLS = false;
    private bool usedYahtzee = false;
    private bool usedChance = false;
    private int scoring = 0;

    private int[] dummy = new int[5]; // Dummy holding dice array
    private bool[] upperUsed = new bool[6]; // Marks whether respective upper is used

    public void DisplayAvaliableScoring()
    {
        
    }

    private static int[] GetCount(int[] holdingDice) // Counts the number of times a number appears
    {
        int[] counts = new int[6]; // Each number represents their count 1-6
        for (int i = 0; i < holdingDice.Length; i++)
        {
            counts[holdingDice[i] - 1]++;
        }
        return counts;
    }

    // Upper -----------------------------------------------

    private bool ScoreUpper(int upperValue)
    {
        int upperIndex = upperValue - 1;
        int[] counts = GetCount(dummy);
        if (upperUsed[upperIndex]) return false; // Used

        if (counts[upperIndex] > 0)
        {
            upperUsed[upperIndex] = true; // Mark as scored
            return true;
        }
        return false;
    }
    public bool GetOne() => ScoreUpper(1);
    public bool GetTwo() => ScoreUpper(2);
    public bool GetThree() => ScoreUpper(3);
    public bool GetFour() => ScoreUpper(4);
    public bool GetFive() => ScoreUpper(5);
    public bool GetSix() => ScoreUpper(6);


    // Lower -----------------------------------------------

    public bool GetTK()
    {
        if (usedTK) return false;
        int[] counts = GetCount(dummy); // Count each die face

        for (int i = 0; i < counts.Length; i++)
        {
            // Check if any number appears 3 or more times
            if (counts[i] >= 3)
            {
                usedTK = true;
                return usedTK;
            }
        }
        return false;
    }

    public bool GetFK()
    {
        if (usedFK) return false;
        int[] counts = GetCount(dummy); // Count each die face

        for (int i = 0; i < counts.Length; i++)
        {
            // Check if any number appears 4 or more times
            if (counts[i] >= 4)
            {
                usedFK = true;
                return usedFK;
            }
        }
        return false;
    }
    public bool GetFH()
    {
        int[] counts = new int[7]; // num on die
        bool hasThree = false;
        bool hasTwo = false;

        // Count each die face
        for (int i = 0; i < dummy.Length; i++)
        {
            counts[dummy[i]]++;
        }

        // Check for three of a kind and a pair
        for (int i = 1; i <= 6; i++)
        {
            if (counts[i] == 3)
            {
                hasThree = true;
            }
            else if (counts[i] == 2)
            {
                hasTwo = true;
            }
        }

        if (hasThree && hasTwo)
        {
            usedFH = true;
            return usedFH;
        }

        return false;
    }


    public bool GetSS()
    {
        int[] straights = { 1, 2, 3, 4, 5 };

        
        for (int i = 0; i < straights.Length; i++)
        {
            bool found = false;

            // Check if num exists in array
            for (int j = 0; j < dummy.Length; j++)
            {
                if (dummy[j] == straights[i])
                {
                    found = true;
                    break;
                }
            }

            // checks if num in the straight is missing
            if (!found)
            {
                usedSS = true;
                return usedSS;
            }
        }

        return false;
    }

    public bool GetLS()
{
    int[] straights = { 2, 3, 4, 5, 6 };

    // checks all nums
    for (int i = 0; i < straights.Length; i++)
    {
        bool found = false;

        // Check if num exists in array
        for (int j = 0; j < dummy.Length; j++)
        {
            if (dummy[j] == straights[i])
            {
                found = true;
                break;
            }
        }

        // checks if a num is missing
        if (!found)
        {
            usedLS = true;
            return usedLS;
        }
    }


    return false;
}
    public bool GetYahtzee()
    {
        if (usedYahtzee) return false;
        int firstValue = dummy[0];
        for (int i = 1; i < dummy.Length; i++)
        {
            if (dummy[i] != firstValue)
            {
                return false;
            }
        }
        usedYahtzee = true;
        return true;
    }
    public bool GetChance()
    {
        usedChance = true;
        return usedChance;
    }
}
    