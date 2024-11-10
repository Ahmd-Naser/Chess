using testForChess.Abstract;
using testForChess.Pieces;
using testForChess.Helpers;
using testForChess.Interfaces;
using testForChess.MovePieces;
using static testForChess.Helpers.PrintAndBuild;
using static testForChess.Helpers.MovesValidator;
using static testForChess.Helpers.Errors;

namespace testForChess;
using static System.Console;
public class Point
{
    public int x;
    public int y;

    public Point()
    {
        x = y = -1;
    }
}

class Program
{

    static void Main(string[] args)
    {
        var ate1 = new List<Cell>();
        var ate2 = new List<Cell>();
        
        
        Cell[,] board = new Cell[10, 10];
        BuildBoard(board);
        //PrintBoard(board , ate1 , ate2);

        //PrintRotatedBoard(board);

        //PrintAndBuild.TestBoard();

        // start game

        bool turn = true;
        byte player = 1;

     
        
        while (true)
        {
            
            if(turn)
                PrintBoard(board , ate1 , ate2);

            else
                PrintRotatedBoard(board , ate1 , ate2);

            if (turn)
                player = 1;
            else
                player = 2;
            

            Point from = new(), to = new();
            string[] line = ReadLine().Split(" ");
            
            from.x = int.Parse(line[0]);
            from.y = int.Parse(line[1]);

            line = ReadLine().Split(" ");

            to.x = int.Parse(line[0]);
            to.y = int.Parse(line[1]);


            if (OutBounds(from, to))
            {
                OutOfBounds();
                continue;
            }

            if (!IsMine(player, board[from.x, from.y]))
            {
                InvalidSelect();
                continue;
            }

            if (IsMine(player, board[to.x, to.y]))
            {
                InvalidMove();
                continue;
            }

            if (!MovePiece.MovePice(from, to, board, ate1, ate2))
            {
                InvalidMove();
                continue;
            }


            turn ^= true;
        }
        
        
    }
}

