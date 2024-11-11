using Chess.Abstract;
using Chess.Helpers;
using Chess.Pieces;

using static Chess.Helpers.MovesValidator;
using static Chess.Helpers.Operations;

namespace Chess.MovePieces;

public class MovePawn 
{
   
    public static bool Move(Point from, Point to, Cell[,] board, List<Cell> ate1 , List<Cell> ate2)
    {

        byte player = board[from.x, from.y].Player;

        int deltaX = Math.Abs(from.x - to.x);

        if (deltaX > 2)
            return false;

        int diffx = to.x - from.x;
        int diffy = to.y - from.y;

        Pawn cell = (Pawn)board[from.x, from.y];
        
        if (player == 1)
        {

            if (diffx == -1 && (diffy == -1 || diffy == 1) && !IsEmpty(board[to.x, to.y]))
            {
                // eat
                cell.Used = true;
                
                Eat(from , to , board , ate1);
                
                return true;
            }
            
            else if (diffy == 0 && (diffx == -1 || (diffx == -2 && !cell.Used )) && IsEmpty(board[to.x,to.y] ) && IsEmpty(board[from.x-1 , from.y ] ) )
            {                
                cell.Used = true;

                // swap
                Swap(from , to ,board);
                return true;
            }
            
        }

        else
        {
            
            if (diffx == 1 && (diffy == -1 || diffy == 1) && !IsEmpty(board[to.x, to.y]))
            {
                cell.Used = true;

                // eat
                Eat(from , to , board , ate2);

                return true;
            }
            
            else if (diffy == 0 && (diffx == 1 || (diffx == 2 && !cell.Used) ) && IsEmpty(board[to.x,to.y] ) && IsEmpty(board[from.x+1 , from.y ] ) )
            {
                cell.Used = true;

                // swap
                Swap(from , to ,board);

                return true;
            }
            
        }

        return false;
    }
}