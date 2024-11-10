using testForChess.Abstract;
using static testForChess.MovePieces.MovePawn;
namespace testForChess.MovePieces;

public class MovePiece
{

    public static bool MovePice(Point from, Point to, Cell[,] board, List<Cell> ate1, List<Cell> ate2)
    {
        var symbol = board[from.x, from.y].Symbol;

        if (symbol == 'P')
            return MovePawn.Move(from, to, board, ate1, ate2);

        if (symbol == 'K')
            return MoveKing.Move(from, to, board, ate1, ate2);

        if (symbol == 'Q')
            return MoveQueen.Move(from, to, board, ate1, ate2);

        if (symbol == 'B')
            return MoveBishop.Move(from, to, board, ate1, ate2);

        if (symbol == 'N')
            return MoveKnight.Move(from, to, board, ate1, ate2);

        if (symbol == 'R')
            return MoveRock.Move(from, to, board, ate1, ate2);
        
        return false;
    }
}