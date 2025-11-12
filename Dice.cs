public class Dice
{
    private Random r = new Random();

    private int[] dice = new int[5]; // current dice values
    private bool[] held = new bool[5]; // whether each die is held
    private int[] holding = new int[5]; // final values after stop
    private int rollCount = 0;
    private void ResetDice() // Reset held state and dice at the start of each round
    {
        rollCount = 0;
        for (int i = 0; i < 5; i++)
        {
            held[i] = false;
            dice[i] = 0;
            holding[i] = 0;
        }
    }
    public void DiceMutator() // ⚀⚁⚂⚃⚄⚅
    {
        ResetDice();
        DieRoll();


        while (rollCount < 3)
        {
            DisplayDice();

            Console.WriteLine("To hold enter 1. To unhold enter 2.");
            Console.WriteLine("To reroll enter 3. To stop enter anything else.");

            string input = Console.ReadLine();
            int dieNumber;

            if (input == "1") // hold
            {
                while (true)
                {
                    Console.WriteLine("Enter die number (1-5) to hold:");
                    if (int.TryParse(Console.ReadLine(), out dieNumber) && dieNumber >= 1 && dieNumber <= 5)
                    {
                        held[dieNumber - 1] = true;
                        Console.WriteLine($"Die {dieNumber} is now held.");
                        break;
                    } else
                    {
                        Console.WriteLine("Invalid input. Please input a number between 1 and 5.");
                    }
                }
            }
            else if (input == "2") // unhold
            {
                while (true)
                {
                    Console.WriteLine("Enter die number (1-5) to unhold:");
                    if (int.TryParse(Console.ReadLine(), out dieNumber) && dieNumber >= 1 && dieNumber <= 5)
                    {
                        held[dieNumber - 1] = false;
                        Console.WriteLine($"Die {dieNumber} is now released.");
                        break;
                    } else
                    {
                        Console.WriteLine("Invalid input. Please input a number between 1 and 5.");
                    }
                }
            }
            else if (input == "3") // reroll
            {
                rollCount++;
                if (rollCount == 3)
                {
                    Console.WriteLine("That's 3 rolls!");
                    FinalizeDice();
                    break;
                }
                else
                {
                    DieRoll();
                }
            }
            else // stop early
            {
                FinalizeDice();
                break;
            }
        }
    }

    private void DieRoll()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!held[i])
                dice[i] = r.Next(1, 7);
        }
    }

    private void DisplayDice() // Green for held dice
    {
        for (int i = 0; i < 5; i++) // Colour brought to you by Matthew
        {
            if (held[i])
            {
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.Write($"Die{i + 1}:({dice[i]}) ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write($"Die{i + 1}:({dice[i]}) ");
            }
        }
        Console.WriteLine();
    }

    private void FinalizeDice()
    {
        for (int i = 0; i < 5; i++)
            holding[i] = dice[i];

        Console.WriteLine("Your final dice:");
        Console.WriteLine(string.Join(" ", holding));
    }

    public int[] GetHoldRoll()
    {
        return holding;
    }
}
