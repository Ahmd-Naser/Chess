namespace testForChess.Helpers;
using static System.Console;

public class Errors
{
    public static void InvalidMove()
    {
        
        WriteLine("Invalid Move ... please try again");
    }

    public static void InvalidSelect()
        => WriteLine("please select a peice belong to you");

    public static void OutOfBounds()
        => WriteLine("Out of bounds .. please try again");
}