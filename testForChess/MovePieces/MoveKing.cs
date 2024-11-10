using testForChess.Abstract;

namespace testForChess.MovePieces;
using static testForChess.Helpers.MovesValidator;
using static testForChess.Helpers.Operations;

public class MoveKing
{
    
    private static int[] dx = new int[] { 1 , 1 , 1 , 0 , 0 , -1 , -1 , -1 };
    private static int[] dy = new int[] { 1 , 0 , -1 , 1 , -1 , 1 , 0 , -1 };
    
    public static bool Move(Point from, Point to, Cell[,] board, List<Cell> ate1, List<Cell> ate2)
    {
        byte player = board[from.x, from.y].Player;

        for (int i = 0; i < 8; i++)
        {
            int nx = from.x + dx[i], ny = from.y + dy[i];

            if (nx == to.x && ny == to.y)
            {
                if (IsEmpty(board[nx, ny]))
                    Swap(from, to, board);
                else
                    Eat(from , to , board , (player == 1 ? ate1 : ate2 ) );

                return true;
            }
        }
        
        return false;
        
    }
}