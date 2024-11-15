using Chess.Abstract;

namespace Chess.Pieces;


public class Pawn : Cell
{

    public Pawn()
    {
        Symbol = '♙';
    }

    public Pawn(byte player)
    {
        Player = player;
        Symbol = '♙';
    }
   
}