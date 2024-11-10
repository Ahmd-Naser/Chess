using testForChess.Abstract;

namespace testForChess.Pieces;


public class Rook : Cell
{

    public Rook()
    {
        Symbol = 'R';
    }

    public Rook(byte player)
    {
        Player = player;
        Symbol = 'R';
    }
    
}