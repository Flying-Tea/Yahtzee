public class Dice
{
    Random r = new Random();

    int die1;
    int die2;
    int die3;
    int die4;
    int die5;
    
    public Dice()
    {
        
        die1 = r.Next(1, 7);
    }

}