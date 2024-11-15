using Chess.Abstract;

namespace Chess.Pieces;


public class Queen : Cell
{
    public Queen(byte player)
    {
        Player = player;
        Symbol = (char)PieceSympol.Queen;
    }
    
}