using Chess.Abstract;

namespace Chess.Pieces;


public class Rook : Cell
{

    public Rook()
    {
        Symbol = '♖';
    }

    public Rook(byte player)
    {
        Player = player;
        Symbol = '♖';
    }
    
}