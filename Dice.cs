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
        
    public void DiceMutator()
    {
        DieRoll();

        for (int i = 0; i <= 3; i++)
        {
            string input = Console.ReadLine();
            int dieNumber;

            if (int.TryParse(input, out dieNumber))
            {

                //diceArray[dieNumber - 1] = die{dieNumber};
                if (input == "1")
                {
                    holding[dieNumber] = die1;
                    roll1 = true;
                }
                else if (input == "2")
                {
                    holding[dieNumber] = die2;
                    roll2 = true;
                }
                else if (input == "3")
                {
                    holding[dieNumber] = die3;
                    roll3 = true;
                }
                else if (input == "4")
                {
                    holding[dieNumber] = die4;
                    roll4 = true;
                }
                else if (input == "5")
                {
                    holding[dieNumber] = die5;
                    roll5 = true;
                }
            }
            else if (input == "R")
            {
                DieRoll();
            }
            else
            {
                Console.WriteLine("You stop running.");
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
        else if (roll2 == false)
        {
            die2 = r.Next(1, 7);
        }
        else if (roll3 == false)
        {
            die3 = r.Next(1, 7);
        }
        else if (roll4 == false)
        {
            die4 = r.Next(1, 7);
        }
        else if (roll5 == false)
        {
            die5 = r.Next(1, 7);
        }
        

        Console.WriteLine($"Die 1: {die1} Die 2: {die2} Die 3: {die3} Die 4: {die4} Die 5: {die5}");
        Console.WriteLine($"Press 1 - 5 to hold their die. To reroll enter R. To stop enter S");
    }
    public int[] GetHoldRoll()
    {
        return holding;
    }
}