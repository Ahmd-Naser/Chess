using testForChess.Abstract;

namespace testForChess.Pieces;


public class Bishop : Cell
{

    public Bishop()
    {
        Symbol = 'B';
    }

    public Bishop(byte player)
    {
        Player = player;
        Symbol = 'B';
    }
    
}