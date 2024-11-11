using Chess.Abstract;

namespace Chess.Pieces;


public class Empty : Cell
{
    public Empty()
    {
        Symbol = 'E';
    }

    public Empty(byte player)
    {
        Symbol = 'E';
        Player = player;
    }
    
}