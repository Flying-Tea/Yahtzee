class ScoreRules
{
    // VERY IMPORTANT: (For future reference)
    // Category is already used, or if its not used + no match
    // Outputs true if not used + dice match

    private bool usedTK = false;
    private bool usedFK = false;
    private bool usedFH = false;
    private bool usedSS = false;
    private bool usedLS = false;
    private bool usedYahtzee = false;
    private bool usedChance = false;
    public bool GetIsTKUsed() => usedTK;
    public bool GetIsFKUsed() => usedFK;
    public bool GetIsFHUsed() => usedFH;
    public bool GetIsSSUsed() => usedSS;
    public bool GetIsLSUsed() => usedLS;
    public bool GetIsYahtzeeUsed() => usedYahtzee;
    public bool GetIsChanceUsed() => usedChance;

    private int[] holdingDice = new int[5]; // holdingDice holding dice array
    private bool[] upperUsed = new bool[6]; // Marks whether respective upper is used
    public bool GetIsUpperUsed(int upperValue) => upperUsed[upperValue - 1];

    public void SetDice(int[] holdingDice)
    {
        this.holdingDice = holdingDice;
    }

    private int SumOfHolding()
    {
        int sum = 0;
        for (int i = 0; i < holdingDice.Length; i++)
        {
            sum += holdingDice[i];
        }
        return sum;
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

    public bool IsUpperValid(int upperValue)
    {
        int upperIndex = upperValue - 1;
        int[] counts = GetCount(holdingDice);
        if (upperUsed[upperIndex]) return false; // Used
        if (counts[upperIndex] > 0) return true; // Checks if respective count is > 0
        return false;
    }

    public bool UseUpper(int upperValue) // Use respective value when called
    {
        if (!upperUsed[upperValue - 1])
        {
            upperUsed[upperValue - 1] = true;
            return true;
        }
        return false;
    }
    public int PreviewPointsUpper(int upperValue) // Respective Points for Upper
    {
        int[] counts = GetCount(holdingDice);
        return counts[upperValue - 1] * upperValue; // If outputs 0 that means that choice is invalid
    }

    public bool UseOne() => UseUpper(1);
    public bool UseTwo() => UseUpper(2);
    public bool UseThree() => UseUpper(3);
    public bool UseFour() => UseUpper(4);
    public bool UseFive() => UseUpper(5);
    public bool UseSix() => UseUpper(6);

    // Lower -----------------------------------------------

    private bool HasStraight(int straightLength)
    {
        int[] counts = GetCount(holdingDice);
        int consecutive = 0;
        for (int i = 0; i < counts.Length; i++)
        {
            if (counts[i] > 0) // Checks each consecutive number of rolls is greater than 0 otherwise reset consecutive to 0
            {
                consecutive++;
                if (consecutive >= straightLength)
                {
                    return true;
                }
            }
            else
            {
                consecutive = 0;
            }
        }
        return false;
    }

    public bool IsTKValid() // Three of a Kind -------
    {
        if (usedTK) return false;
        int[] counts = GetCount(holdingDice); // Count each die face

        for (int i = 0; i < counts.Length; i++)
        {
            // Check if any number appears 4 or more times
            if (counts[i] >= 3)
            {
                return true;
            }
        }
        return false;
    }

    public bool UseTK()
    {
        if (!usedTK)
        {
            usedTK = true;
            return true;
        }
        return false;
    }

    public bool IsFKValid() // Four of a Kind -------
    {
        if (usedFK) return false;
        int[] counts = GetCount(holdingDice); // Count each die face

        for (int i = 0; i < counts.Length; i++)
        {
            // Check if any number appears 4 or more times
            if (counts[i] >= 4)
            {
                return true;
            }
        }
        return false;
    }

    public bool UseFK()
    {
        if (!usedFK)
        {
            usedFK = true;
            return true;
        }
        return false;
    }

    public bool IsFHValid() // Full House -------
    {
        if (usedFH) return false;
        int[] counts = GetCount(holdingDice); // num on die
        bool hasThree = false;
        bool hasTwo = false;

        // Count each die face
        for (int i = 0; i < counts.Length; i++)
        {
            if (counts[i] == 3) // Check for three of a kind and a pair
            {
                hasThree = true;
            }
            else if (counts[i] == 2)
            {
                hasTwo = true;
            }
        }
        return hasThree && hasTwo;
    }

    public bool UseFH()
    {
        if (!usedFH)
        {
            usedFH = true;
            return true;
        }
        return false;
    }

    public bool IsSSValid() // Small Straight -------
    {
        return (!usedSS) && HasStraight(4);
    }

    public bool UseSS()
    {
        if (!usedSS)
        {
            usedSS = true;
            return true;
        }
        return false;
    }

    public bool IsLSValid() // Large Straight -------
    {
        return (!usedLS) && HasStraight(5);
    }

    public bool UseLS()
    {
        if (!usedLS)
        {
            usedLS = true;
            return true;
        }
        return false;
    }

    public bool IsYahtzeeValid()  // Yahtzee -------
    {
        if (usedYahtzee) return false;
        int first = holdingDice[0];
        for (int i = 1; i < holdingDice.Length; i++)
        {
            if (holdingDice[i] != first)
            {
                return false;
            }
        }
        return true;
    }

    public bool UseYahtzee()
    {
        if (!usedYahtzee)
        {
            usedYahtzee = true;
            return true;
        }
        return false;
    }
    public bool IsChanceAvailable() //  Chance -------
    {
        if (usedChance) return false;

        // Ensure all dice slots are filled (no zero values)
        foreach (int die in holdingDice)
        {
            if (die == 0) return false;
        }

        return true;
    }

    public bool UseChance()
    {
        if (!usedChance)
        {
            usedChance = true;
            return true;
        }
        return false;
    }
    // Lower Points Preview -----------------------------------------------

    public int PreviewTKPoints()
    {
        return IsTKValid() ? SumOfHolding() : 0; // This creates a type of if else statement. if true return SumOfHolding() else return 0
    }
    public int PreviewFKPoints()
    {
        return IsFKValid() ? SumOfHolding() : 0;
    }
    public int PreviewFHPoints()
    {
        return IsFHValid() ? 25 : 0;
    }

    public int PreviewSSPoints()
    {
        return IsSSValid() ? 30 : 0;
    }

    public int PreviewLSPoints()
    {
        return IsLSValid() ? 40 : 0;
    }

    public int PreviewYahtzeePoints()
    {
        return IsYahtzeeValid() ? 50 : 0;
    }

    public int PreviewChancePoints()
    {
        return IsChanceAvailable() ? SumOfHolding() : 0;
    }
}

