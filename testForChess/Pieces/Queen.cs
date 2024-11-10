using testForChess.Abstract;

namespace testForChess.Pieces;


public class Queen : Cell
{

    public Queen()
    {
        Symbol = 'Q';
    }

    public Queen(byte player)
    {
        Player = player;
        Symbol = 'Q';
    }
    
}