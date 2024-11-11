using Chess.Abstract;

namespace Chess.Pieces;


public class Knight : Cell
{

    public Knight()
    {
        Symbol = '♘';
    }

    public Knight(byte player)
    {
        Player = player;
        Symbol = '♘';
    }
 
}
