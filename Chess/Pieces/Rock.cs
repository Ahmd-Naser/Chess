using Chess.Abstract;

namespace Chess.Pieces;


public class Rook : Cell
{

    public Rook(byte player)
    {
        Player = player;
        Symbol = (char)PieceSympol.Rook;
    }
    
}