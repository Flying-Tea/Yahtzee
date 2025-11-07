class Scoring(){

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


    public bool GetOne()
    {
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

    public bool GetTK() //three of a kind
    {
        for (int i = 0; i <= dummy.Length - 1; i++)
        {
            if (dummy[i] == 6)
            {
                if (tKind == false)
                {
                    tKind = true;
                    return tKind;
                }
            }
        }
        return false;
    }
}