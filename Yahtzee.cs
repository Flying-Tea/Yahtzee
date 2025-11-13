class Yahtzee
{
    Dice Roll = new Dice();
    private ScoreRules rules;
    private Scorecard scorecard;
    private int Score = 0;
    private int RoundCounter = 0;
    private bool isBonusAdded = false;
    public Yahtzee()
    {
        rules = new ScoreRules();
        scorecard = new Scorecard(rules);
    }
    private void DisplayRules()
    {
        Console.WriteLine("Welcome to Yahtzee, in this game you will roll 5 dices");
        Thread.Sleep(500);
        Console.WriteLine("With those 5 dices you try to aqcuire the highest score possible\n");
        Thread.Sleep(500);
        Console.WriteLine("You will have 3 re-rolls, you're able to pick up whatever dice you want");
        Thread.Sleep(500);
        Console.WriteLine("You can hold and unhold dice, but held dice only persist for one round\n");
        Thread.Sleep(500);
        Console.WriteLine("This game consists of 13 rounds, or until theres no more options to be chosen");
        Thread.Sleep(1500);
        Console.WriteLine("Scoring in this game is a bit challenging, you can only score each type once");
        Thread.Sleep(500);
        Console.WriteLine("Upper: You can score any of the same number and recieve their sum as the score");
        Thread.Sleep(500);
        Console.WriteLine("Upper Bonus: Once you achieve 63+ points in upper you get a bonus of 35 points");
        Thread.Sleep(500);
        Console.WriteLine("3 Of a kind: Get three dices with the same number, scores the sum of the dice");
        Thread.Sleep(500);
        Console.WriteLine("4 Of a kind: Get four dices with the same number, scores the sum of the dice");
        Thread.Sleep(500);
        Console.WriteLine("Full house: Get three dices with the same number and a pair (2 of the same), scores 25");
        Thread.Sleep(500);
        Console.WriteLine("Small Straight: Get four sequential dice. Scores 30 points");
        Thread.Sleep(500);
        Console.WriteLine("Large Straight: Get five sequential dice. Scores 40 points");
        Thread.Sleep(500);
        Console.WriteLine("Chance: You can put anything into chance. Scores the sum of the dice");
        Thread.Sleep(500);
        Console.WriteLine("YAHTZEE: Five of a kind. Scores 50 points"); 
    }
    public void Play()
    {
        DisplayRules();
        while (RoundCounter < 13)
        {
            Console.WriteLine($"\n--- Round {RoundCounter + 1} ---");
            Roll.DiceMutator();
            rules.SetDice(Roll.GetHoldRoll());
            scorecard.DisplayFullScorecard();
            HandleUserSelection();

            RoundCounter++;
        }
        Console.WriteLine("\nGame Over!");
        Console.WriteLine($"Final Score: {Score}");
    }

    private void HandleUserSelection()
    {
        int points = 0;
        bool validChoice = false;
        while (!validChoice)
        {
            Console.WriteLine("Select a category (e.g., '1', '2', 'TK', 'FK', 'FH', 'SS', 'LS', 'CH', 'YA'):");
            Console.WriteLine(string.Join(" ", Roll.GetHoldRoll()));
            string choice = Console.ReadLine().Trim().ToUpper();

            switch (choice)
            {
                case "1": points = scorecard.SelectUpper(1); break;
                case "2": points = scorecard.SelectUpper(2); break;
                case "3": points = scorecard.SelectUpper(3); break;
                case "4": points = scorecard.SelectUpper(4); break;
                case "5": points = scorecard.SelectUpper(5); break;
                case "6": points = scorecard.SelectUpper(6); break;
                case "TK": points = scorecard.SelectTK(); break;
                case "FK": points = scorecard.SelectFK(); break;
                case "FH": points = scorecard.SelectFH(); break;
                case "SS": points = scorecard.SelectSS(); break;
                case "LS": points = scorecard.SelectLS(); break;
                case "CH": points = scorecard.SelectChance(); break;
                case "YA": points = scorecard.SelectYahtzee(); break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    points = -1; // retry
                    break;
            }

            if (points >= 0) // valid or forfeited
            {
                validChoice = true;
                if (scorecard.GetUpperBonus() > 0 && !isBonusAdded)
                {
                    points += scorecard.GetUpperBonus();
                    isBonusAdded = true;
                    Console.WriteLine("Upper section bonus score achieved! +35 points");
                }
                Score += points;
                Console.WriteLine($"You scored {points} points this round. Total score: {Score}");
            }
            else
            {
                Console.WriteLine("That category is already used. Pick another.");
            }
        }
    }
}