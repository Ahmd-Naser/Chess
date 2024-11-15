using Chess.Abstract;
using Chess.Helpers;

namespace Chess.MovePieces;

public class MovePiece
{

    public static bool MovePice(Point from, Point to, Cell[,] board, List<Cell> ate1, List<Cell> ate2)
    {
        var symbol = board[from.x, from.y].Symbol;

        return symbol switch
        {
            '♙' => MovePawn.Move(from, to, board, ate1, ate2) ,
            '♔' => MoveKing.Move(from, to, board, ate1, ate2) ,
            '♕' => MoveQueen.Move(from, to, board, ate1, ate2) ,
            '♗' => MoveBishop.Move(from, to, board, ate1, ate2) ,
            '♘' => MoveKnight.Move(from, to, board, ate1, ate2) ,
            '♖' => MoveRock.Move(from, to, board, ate1, ate2) ,
            _ => false
        };

    }
}