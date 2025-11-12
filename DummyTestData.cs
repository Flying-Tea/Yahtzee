class DummyTestData
{
    public void RunTests()
    {
        ScoreRules rules = new ScoreRules();
        Scorecard card = new Scorecard(rules);

        // Test Case 1: Full House
        int[] dice1 = { 1, 1, 1, 2, 2 };
        rules.SetDice(dice1);
        card.DisplayFullScorecard();

        Console.WriteLine("Test Case 1: Full House");
        Console.WriteLine("Dice: ");
        Console.WriteLine(string.Join(" ", dice1));
        if (rules.IsFHValid() && rules.PreviewFHPoints() == 25)
            Console.WriteLine("Result: True\n");
        else
            Console.WriteLine("Result: False\n");

        // Test Case 2: Yahtzee 
        int[] dice2 = { 6, 6, 6, 6, 6 };
        rules.SetDice(dice2);
        card.DisplayFullScorecard();

        Console.WriteLine("Test Case 2: Yahtzee");
        Console.WriteLine("Dice: ");
        Console.WriteLine(string.Join(" ", dice2));
        if (rules.IsYahtzeeValid() && rules.PreviewYahtzeePoints() == 50)
            Console.WriteLine("Result: True\n");
        else
            Console.WriteLine("Result: False\n");

        // Test Case 3: Large Straight 
        int[] dice3 = { 2, 3, 4, 5, 6 };
        rules.SetDice(dice3);
        card.DisplayFullScorecard();

        Console.WriteLine("Test Case 3: Large Straight");
        Console.WriteLine("Dice: ");
        Console.WriteLine(string.Join(" ", dice3));
        if (rules.IsLSValid() && rules.PreviewLSPoints() == 40)
            Console.WriteLine("Result: True\n");
        else
            Console.WriteLine("Result: False\n");

        // Test Case 4: Three of a Kind 
        int[] dice4 = { 3, 3, 3, 4, 5 };
        rules.SetDice(dice4);
        card.DisplayFullScorecard();

        Console.WriteLine("Test Case 4: Three of a Kind");
        Console.WriteLine("Dice: ");
        Console.WriteLine(string.Join(" ", dice4));
        if (rules.IsTKValid() && rules.PreviewTKPoints() == 18)
            Console.WriteLine("Result: True\n");
        else
            Console.WriteLine("Result: False\n");

        // Test Case 5: Four of a Kind 
        int[] dice5 = { 4, 4, 4, 4, 2 };
        rules.SetDice(dice5);
        card.DisplayFullScorecard();

        Console.WriteLine("Test Case 5: Four of a Kind");
        Console.WriteLine("Dice: ");
        Console.WriteLine(string.Join(" ", dice5));
        if (rules.IsFKValid() && rules.PreviewFKPoints() == 18)
            Console.WriteLine("Result: True\n");
        else
            Console.WriteLine("Result: False\n");

        // Test Case 6: Small Straight 
        int[] dice6 = { 1, 2, 3, 4, 5 };
        rules.SetDice(dice6);
        card.DisplayFullScorecard();

        Console.WriteLine("Test Case 6: Small Straight");
        Console.WriteLine("Dice: ");
        Console.WriteLine(string.Join(" ", dice6));
        if (rules.IsSSValid() && rules.PreviewSSPoints() == 30)
            Console.WriteLine("Result: True\n");
        else
            Console.WriteLine("Result: False\n");

        // Test Case 7: Chance ===
        int[] dice7 = { 2, 2, 3, 3, 4 };
        rules.SetDice(dice7);
        card.DisplayFullScorecard();

        Console.WriteLine("Test Case 7: Chance");
        Console.WriteLine("Dice: ");
        Console.WriteLine(string.Join(" ", dice7));
        if (rules.IsChanceAvailable() && rules.PreviewChancePoints() == 14)
            Console.WriteLine("Result: True\n");
        else
            Console.WriteLine("Result: False\n");

        Console.WriteLine("--- All test cases complete ---");
    }
}
