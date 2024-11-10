using testForChess.Abstract;

namespace testForChess.Pieces;


public class Knight : Cell
{

    public Knight()
    {
        Symbol = 'N';
    }

    public Knight(byte player)
    {
        Player = player;
        Symbol = 'N';
    }
 
}
