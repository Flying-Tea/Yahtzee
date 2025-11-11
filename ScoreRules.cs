class ScoreRules()
{
    // VERY IMPORTANT IT OUTPUTS FALSE WHENEVER: (For future reference)
    // Category is already used, or if its not used + no match
    // Outputs true if not used + dice match 

    private bool tKind = false;
    private bool fKind = false;
    private bool fHouse = false;
    private bool smStraight = false;
    private bool lgStraight = false;
    private bool yahtzee = false;
    private bool chance = false;
    private int scoring = 0;

    private int[] dummy = new int[5];
    private bool[] upperUsed = new bool[6]; // Marks whether respective upper is used

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
        int[] counts = new int[7]; // num on die

        // Count each die face
        for (int i = 0; i < dummy.Length; i++)
        {
            counts[dummy[i]]++;
        }

        // Check if any number appears 3 or more times
        for (int i = 1; i <= 6; i++)
        {
            if (counts[i] >= 3)
            {
                tKind = true;
                return tKind;
            }
        }

        return false;
    }
    public bool GetFK()
    {
        int[] counts = new int[7]; // num on die

        // Count each die face
        for (int i = 0; i < dummy.Length; i++)
        {
            counts[dummy[i]]++;
        }

        // Check if any number appears 4 or more times
        for (int i = 1; i <= 6; i++)
        {
            if (counts[i] >= 4)
            {
                fKind = true;
                return fKind;
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
            fHouse = true;
            return fHouse;
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
                smStraight = true;
                return smStraight;
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
            lgStraight = true;
            return lgStraight;
        }
    }


    return false;
}
    public bool GetYahtzee()
    {
        int firstValue = dummy[0];
        for (int i = 1; i < dummy.Length; i++)
        {
            if (dummy[i] != firstValue)
            {
                yahtzee = true;
                return yahtzee;
            }
        }
        return true;
    }
    public bool GetChance()
    {
        chance = true;
        return chance;
    }
}
    