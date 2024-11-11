using Chess.Abstract;
using Chess.Helpers;

namespace Chess.MovePieces;

public class MovePiece
{

    public static bool MovePice(Point from, Point to, Cell[,] board, List<Cell> ate1, List<Cell> ate2)
    {
        var symbol = board[from.x, from.y].Symbol;

        if (symbol == '♙')
            return MovePawn.Move(from, to, board, ate1, ate2);

        if (symbol == '♔')
            return MoveKing.Move(from, to, board, ate1, ate2);

        if (symbol == '♕')
            return MoveQueen.Move(from, to, board, ate1, ate2);

        if (symbol == '♗')
            return MoveBishop.Move(from, to, board, ate1, ate2);

        if (symbol == '♘')
            return MoveKnight.Move(from, to, board, ate1, ate2);

        if (symbol == '♖')
            return MoveRock.Move(from, to, board, ate1, ate2);
        
        return false;
    }
}