using Chess.Abstract;

namespace Chess.Pieces;


public class Pawn : Cell
{
    public bool Used;

    public Pawn()
    {
        Symbol = '♙';
        Used = false;
    }

    public Pawn(byte player)
    {
        Player = player;
        Symbol = '♙';
        Used = false;
    }
   
}