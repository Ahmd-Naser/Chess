using Chess.Abstract;

namespace Chess.Pieces;


public class Bishop : Cell
{
    public Bishop(byte player)
    {
        Player = player;
        Symbol = (char)PieceSymbol.Bishop;
    }
    
}