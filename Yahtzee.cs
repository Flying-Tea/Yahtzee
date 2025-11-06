using System.Security.Cryptography.X509Certificates;

class Yahtzee
{
    private int Score = 0;
    private int RoundCounter = 0;

    private int SetScore()
    {
        return Score;
    }
    private void SetDice()
    {
        // calls dice, sets array of dice
    }
    private void DisplayRules()
    {
        Console.WriteLine();
    }
    private void Scorecard()
    {
        // display from scoring class just checks whats avaliable
        // if true
        // 

    }
    public void Play()
    {
        while (true)
        {
            if (RoundCounter <= 13)
            {
                DisplayRules();
                SetDice();

                // Chooses what you want to pick
                // Sends it back to dice class


                Scorecard();
                RoundCounter++;
            }
            if (RoundCounter == 14)
            {
                break;
            }
        }

    }
}