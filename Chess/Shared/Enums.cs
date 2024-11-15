namespace Chess.Shared;

public class Enums
{
    public enum Purpose
    {
        forMove = 1,
        forThreate
    }
    
    public enum PieceSympol
    {
        Pwan = '♙',
        King = '♔',
        Queen = '♕',
        Bishop = '♗' ,
        Knight = '♘' ,
        Rook = '♖',
        Empty = 'E'
    }
}