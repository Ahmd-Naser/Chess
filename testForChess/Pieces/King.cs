using testForChess.Abstract;

namespace testForChess.Pieces;


public class King : Cell
{

    public King()
    {
        Symbol = 'K';
    }

    public King(byte player)
    {
        Player = player;
        Symbol = 'K';
    }
   
}
