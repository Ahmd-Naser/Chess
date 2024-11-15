using Chess.Abstract;

namespace Chess.Pieces;


public class Pawn : Cell
{
    public Pawn(byte player)
    {
        Player = player;
        Symbol = (char)PieceSymbol.Pawn;
    }
   
}