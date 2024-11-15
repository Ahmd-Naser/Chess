namespace Chess.Helpers;
using static System.Console;

public class ErrorMessages
{
    public static void InvalidMoveMessage()
        => WriteLine("Invalid Move ... please try again");
    public static void InvalidSelectMessage()
        => WriteLine("please select a peice belong to you");

    public static void OutOfBoundsMessage()
        => WriteLine("Out of bounds .. please try again");
    
    public static void CheckmateMessage()
        => WriteLine("Checkmate");
    
    
}