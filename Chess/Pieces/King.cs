using Chess.Abstract;

namespace Chess.Pieces;


public class King : Cell
{

    public King()
    {
        Symbol = '♔';
    }

    public King(byte player)
    {
        Player = player;
        Symbol = '♔';
    }
   
}
