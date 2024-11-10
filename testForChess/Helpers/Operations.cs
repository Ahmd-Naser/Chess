using testForChess.Abstract;
using testForChess.Pieces;

namespace testForChess.Helpers;

public class Operations
{
    public static void Swap(Point from , Point to, Cell[,] board)
    {
        (board[from.x, from.y], board[to.x, to.y]) = (board[to.x, to.y], board[from.x, from.y]);
    }

    public static void Eat(Point from , Point to, Cell[,] board, List<Cell> ate)
    {
        ate.Add(board[to.x, to.y ]);

        board[to.x, to.y] = new Empty();
        
        Swap(from , to , board);
    }
}