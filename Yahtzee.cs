using System.Security.Cryptography.X509Certificates;
using System.Threading;

class Yahtzee
{
    Dice Roll = new Dice();
    private ScoreRules rules;
    private Scorecard scorecard;
    private int Score = 0;
    private int RoundCounter = 0;
    public Yahtzee()
    {
        rules = new ScoreRules();
        scorecard = new Scorecard(rules);
    }
    private int SetScore()
    {
        return Score;
    }
    private void DisplayRules()
    {
        Console.WriteLine("Welcome to Yahtzee, in this game you will roll 5 dices");
        Thread.Sleep(500);
        Console.WriteLine("With those 5 dices you try to aqcuire the highest score possible\n");
        Thread.Sleep(500);
        Console.WriteLine("YOu will have 3 re rolls, you're able to pick up whatever dice you want");
        Thread.Sleep(500);
        Console.WriteLine("But once a dice is picked up, it cannot be re rolled, choose wisely\n");
        Thread.Sleep(500);
        Console.WriteLine("This game consists of 13 rounds, or until theres no more options to be chosen");
        Thread.Sleep(1500);
        Console.WriteLine("Scoring in this game is a bit challenging");
        Thread.Sleep(500);
        Console.WriteLine("3 Of a kind: Get three dices with the same number, scores the sum of the dice");
        Thread.Sleep(500);
        Console.WriteLine("4 Of a kind: Get four dices with the same number, scores the sum of the dice");
        Thread.Sleep(500);
        Console.WriteLine("Full house: Get three dices with the same number and a pair (2 of the same), scores 25");
        Thread.Sleep(500);
        Console.WriteLine("Small Straight: Get four sequential dice. Scores 30 points.");
        Thread.Sleep(500);
        Console.WriteLine("Large Straight: Get five sequential dice. Scores 40 points.");
        Thread.Sleep(500);
        Console.WriteLine("Chance: You can put anything into chance. Scores the sum of the dice.");
        Thread.Sleep(500);
        Console.WriteLine("YAHTZEE: Five of a kind. Scores 50 points. Each additional Yahtzee scores 100 extra points."); 
        

    }
    public void Play()
    {
        DisplayRules();
        while (true)
        {
            if (RoundCounter <= 13)
            {

                Roll.DiceMutator();
                rules.SetDice(Roll.holdingDice());
                scorecard.DisplayFullScorecard();


                RoundCounter++;
            }
            else
            {
                break;
            }
        }

    }
}