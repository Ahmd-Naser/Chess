using testForChess.Abstract;

namespace testForChess.MovePieces;

using static testForChess.Helpers.MovesValidator;
using static testForChess.Helpers.Operations;

public class MoveBishop
{
    
    private static int[] dx = new int[] { 1 , 1 , -1 , -1 };
    private static int[] dy = new int[] { 1 , -1 , 1 , -1 };

    public static bool Move(Point from, Point to, Cell[,] board, List<Cell> ate1, List<Cell> ate2)
    {
        byte player = board[from.x, from.y].Player;

        for (int i = 0; i < 4; i++)
        {

            int nx = from.x, ny = from.y;

            bool thereIsObstacle = false;
            
            while (!OutBounds(nx, ny) && !( nx == to.x && ny == to.y )  )
            {
                if (!IsEmpty(board[nx, ny]) && !(nx == from.x && ny == from.y))
                    thereIsObstacle = true;

                nx += dx[i];
                ny += dy[i];
            }

            if (nx == to.x && ny == to.y && !thereIsObstacle )
            {
                if ( IsEmpty(board[nx, ny]))
                    Swap(from , to , board);
            
                else
                    Eat(from , to , board , (player == 1 ? ate1 : ate2) );

                return true;
            }
        }

        return false;
    }

}
