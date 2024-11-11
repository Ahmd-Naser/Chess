using Chess.Abstract;

namespace Chess.Pieces;


public class Queen : Cell
{

    public Queen()
    {
        Symbol = '♕';
    }

    public Queen(byte player)
    {
        Player = player;
        Symbol = '♕';
    }
    
}