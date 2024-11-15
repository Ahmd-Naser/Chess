namespace Chess.Shared;

public class Enums
{
    public enum Purpose
    {
        forMove = 1,
        forThreate
    }
    
    public enum PieceSymbol
    {
        Pawn = '♙',
        King = '♔',
        Queen = '♕',
        Bishop = '♗' ,
        Knight = '♘' ,
        Rook = '♖',
        Empty = 'E'
    }
}