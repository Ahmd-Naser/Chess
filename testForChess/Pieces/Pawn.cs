using testForChess.Abstract;

namespace testForChess.Pieces;


public class Pawn : Cell
{
    public bool Used;

    public Pawn()
    {
        Symbol = 'P';
        Used = false;
    }

    public Pawn(byte player)
    {
        Player = player;
        Symbol = 'P';
        Used = false;
    }
   
}