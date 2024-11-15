using Chess.Abstract;

namespace Chess.Pieces;


public class Knight : Cell
{
    public Knight(byte player)
    {
        Player = player;
        Symbol = (char)PieceSymbol.Knight;
    }
 
}
