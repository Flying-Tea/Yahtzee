public class Dice
{
    Random r = new Random();

    private int die1;
    private int die2;
    private int die3;
    private int die4;
    private int die5;

    private bool roll1;
    private bool roll2;
    private bool roll3;
    private bool roll4;
    private bool roll5;

    private int[] holding = new int[5];

    int i = 0;
    public void DiceMutator() // ⚀⚁⚂⚃⚄⚅
    {
        DieRoll();

        while (i <= 2)
        {
            if (roll1 == true) // If holding the text turns green
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Die1:({die1}) ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else Console.Write($"Die1:({die1}) ");

            if (roll2 == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Die2:({die2}) ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else Console.Write($"Die2:({die2}) ");

            if (roll3 == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Die3:({die3}) ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else Console.Write($"Die3:({die3}) ");

            if (roll4 == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Die4:({die4}) ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else Console.Write($"Die4:({die4}) ");

            if (roll5 == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Die5:({die5}) ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else Console.Write($"Die5:({die5}) ");

            Console.WriteLine("");
            Console.WriteLine("To hold enter 1. To unhold enter 2.");
            Console.WriteLine("To reroll enter 3. To stop enter anything else.");


            string input = Console.ReadLine();
            int dieNumber;

            if (input == "1") // To hold die roll
            {
                Console.WriteLine("From 0 - 4 enter in the number for the die you wish to hold.");
                string holdInput = Console.ReadLine();

                if (int.TryParse(holdInput, out dieNumber))
                {

                    if (holdInput == "0")
                    {
                        holding[dieNumber] = die1;
                        roll1 = true;
                    }
                    else if (holdInput == "1")
                    {
                        holding[dieNumber] = die2;
                        roll2 = true;
                    }
                    else if (holdInput == "2")
                    {
                        holding[dieNumber] = die3;
                        roll3 = true;
                    }
                    else if (holdInput == "3")
                    {
                        holding[dieNumber] = die4;
                        roll4 = true;
                    }
                    else if (holdInput == "4")
                    {
                        holding[dieNumber] = die5;
                        roll5 = true;
                    }
                }
                else
                {
                    Console.WriteLine("Enter in a die you wish to hold.");
                }

            }

            else if (input == "2") // This is to stop holding dice
            {
                Console.WriteLine("From 0 - 4 enter in the number for the die you wish to stop holding.");
                string holdInput = Console.ReadLine();

                if (int.TryParse(holdInput, out dieNumber))
                {

                    if (holdInput == "0")
                    {
                        roll1 = false;
                    }
                    else if (holdInput == "1")
                    {
                        roll2 = false;
                    }
                    else if (holdInput == "2")
                    {
                        roll3 = false;
                    }
                    else if (holdInput == "3")
                    {
                        roll4 = false;
                    }
                    else if (holdInput == "4")
                    {
                        roll5 = false;
                    }
                }
                else
                {
                    Console.WriteLine("Enter in a die you wish to stop holding.");
                }
            }

            else if (input == "3")
            {
                i += 1;

                if (i == 3)
                {
                    Console.WriteLine("That's 3 rolls!");
                    holding[0] = die1;
                    holding[1] = die2;
                    holding[2] = die3;
                    holding[3] = die4;
                    holding[4] = die5;
                    Console.WriteLine("Your rolls:");
                    Console.WriteLine($"{holding[0]} {holding[1]} {holding[2]} {holding[3]} {holding[4]}");
                    break;
                }
                else
                {
                    DieRoll();
                }
            }
            else // Final Dice
            {
                Console.WriteLine("Your rolls:");
                holding[0] = die1;
                holding[1] = die2;
                holding[2] = die3;
                holding[3] = die4;
                holding[4] = die5;
                Console.WriteLine($"{holding[0]} {holding[1]} {holding[2]} {holding[3]} {holding[4]}");
                break;
            }
        }


    }
    private void DieRoll()
    {
        if (roll1 == false)
        {
            die1 = r.Next(1, 7);
        }
        if (roll2 == false)
        {
            die2 = r.Next(1, 7);
        }
        if (roll3 == false)
        {
            die3 = r.Next(1, 7);
        }
        if (roll4 == false)
        {
            die4 = r.Next(1, 7);
        }
        if (roll5 == false)
        {
            die5 = r.Next(1, 7);
        }
        
    }
    public int[] GetHoldRoll()
    {
        return holding;
    }
      
}