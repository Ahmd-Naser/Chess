using Chess.Abstract;

namespace Chess.Pieces;


public class Empty : Cell
{
    public Empty()
    {
        Symbol = (char)PieceSymbol.Empty;
    }
    
}