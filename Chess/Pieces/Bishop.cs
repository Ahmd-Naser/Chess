using Chess.Abstract;

namespace Chess.Pieces;


public class Bishop : Cell
{

    public Bishop()
    {
        Symbol = '♗';
    }

    public Bishop(byte player)
    {
        Player = player;
        Symbol = '♗';
    }
    
}