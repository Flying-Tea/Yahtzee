//Dice dice = new Dice();

class Scoring()
{

    private bool one = false;
    private bool two = false;
    private bool three = false;
    private bool four = false;
    private bool five = false;
    private bool six = false;

    private bool tKind = false;
    private bool fKind = false;
    private bool fHouse = false;
    private bool smStraight = false;
    private bool lgStraight = false;
    private bool yahtzee = false;
    private bool chance = false;
    private int scoring = 0;

    private int[] dummy = new int[5];


    //-----------------------------------------------
    //upper
    public bool GetOne()
    {
        //checks if array has a one
        for (int i = 0; i <= dummy.Length - 1; i++)
        {
            if (dummy[i] == 1)
            {
                if (one == false)
                {
                    one = true;
                    return one;
                }
            }
        }
        return false;
    }
    public bool GetTwo()
    {
        //checks if array has a two
        for (int i = 0; i <= dummy.Length - 1; i++)
        {
            if (dummy[i] == 2)
            {
                if (two == false)
                {
                    two = true;
                    return two;
                }
            }
        }
        return false;
    }
    public bool GetThree()
    {
        //checks if array has a three
        for (int i = 0; i <= dummy.Length - 1; i++)
        {
            if (dummy[i] == 3)
            {
                if (three == false)
                {
                    three = true;
                    return three;
                }
            }
        }
        return false;
    }
    public bool GetFour()
    {
        //checks if array has a four
        for (int i = 0; i <= dummy.Length - 1; i++)
        {
            if (dummy[i] == 4)
            {
                if (four == false)
                {
                    four = true;
                    return four;
                }
            }
        }
        return false;
    }
    public bool GetFive()
    {
        //checks if array has a five
        for (int i = 0; i <= dummy.Length - 1; i++)
        {
            if (dummy[i] == 5)
            {
                if (five == false)
                {
                    five = true;
                    return five;
                }
            }
        }
        return false;
    }
    public bool GetSix()
    {
        //checks if array has a six
        for (int i = 0; i <= dummy.Length - 1; i++)
        {
            if (dummy[i] == 6)
            {
                if (six == false)
                {
                    six = true;
                    return six;
                }
            }
        }
        return false;
    }

    //-----------------------------------------------
    //lower 

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
                return tkind;
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
                return fkind;
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
            return fhouse;
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
    