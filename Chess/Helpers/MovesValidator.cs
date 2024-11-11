using Chess.Abstract;

namespace Chess.Helpers;

public class MovesValidator
{

    public static bool OutBounds(Point from, Point to)
    {
        return !( from.x >= 1 && from.x <= 8 && to.x >= 1 && to.x <= 8 && 
               from.y >= 1 && from.y <= 8 && to.y >= 1 && to.y <= 8 );
    }

    public static bool OutBounds(int i , int j)
    {
        return !(i >= 1 && i <= 8 && j >= 1 && j <= 8);
    }

    public static bool IsMine(byte player, Cell piece)
    {

        return player == piece.Player;
    }

    public static bool IsEmpty(Cell piece)
    {
        return piece.Symbol == 'E';
    }
}