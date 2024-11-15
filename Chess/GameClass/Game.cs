using Chess.Abstract;
using Chess.Helpers;
using Chess.MovePieces;
using Chess.Pieces;

using static System.Console;
using static Chess.Helpers.Print;
using static Chess.Helpers.MovesValidator;
using static Chess.Helpers.ErrorMessages;

namespace Chess.GameClass;

public class Game
{
    private List<Cell> ate1 ;
    private List<Cell> ate2 ;
    
    private Cell[,] board ;

    public Game()
    {

        init();
    }

    private void init()
    {
        BuildBoard();

    }
    
    
    public void Run()
    {
        bool turn = true;
        byte player = 1;
        
        while (true)
        {

            if (turn)
            {
                PrintBoard(board , ate1 , ate2);
                
                player = 1;
            }

            else
            {
                PrintRotatedBoard(board , ate1 , ate2);
                
                player = 2;
            }


            var ValidMoves = GenerateValidMoves.ValidMovesInTurn(player, board);

            if (ValidMoves.Count == 0)
            {
                CheckmateMessage();
                return;
            }

            Point from , to ;
            string[] line = ReadLine().Split(" ");

            from = new Point(line);
            
            line = ReadLine().Split(" ");

            to = new Point(line);

            if (OutBounds(from, to))
            {
                OutOfBoundsMessage();
                continue;
            }

            if (!IsMine(player, board[from.x, from.y]))
            {
                InvalidSelectMessage();
                continue;
            }

            if (IsMine(player, board[to.x, to.y]))
            {
                InvalidMoveMessage();
                continue;
            }
            
            var theMove = new Tuple<Point,Point>(from , to);

            if (!ValidMoves.Contains(theMove))
            {
                WriteLine("not valid move yasta ");
                
                continue;
            }

            if (!MovePiece.MovePice(from, to, board, ate1, ate2))
            {
                InvalidMoveMessage();
                continue;
            }


            turn ^= true;
        }
    }
    public void BuildBoard()
    {
        board = new Cell[10, 10];
        ate1 = new ();
        ate2 = new ();
        
        
        char cur = 'a';
        
        for (int i = 1; i <= 8; i++)
        {
            board[0, i] = new Empty();
            board[0, i].Symbol = cur;
            
            board[9, i] = new Empty();
            board[9, i].Symbol = cur++;


            board[i, 0] = new Empty();
            board[i, 0].Symbol = char.Parse(i.ToString() );
            
            board[i, 9] = new Empty();
            board[i, 9].Symbol = char.Parse(i.ToString() );


            board[2, i] = new Pawn(2);
            board[7, i] = new Pawn(1);
            
        }

        board[1, 1] = new Rook(2);
        board[1, 8] = new Rook(2);
        board[1, 2] = new Knight(2);
        board[1, 7] = new Knight(2);
        board[1, 3] = new Bishop(2);
        board[1, 6] = new Bishop(2);
        board[1, 5] = new King(2);
        board[1, 4] = new Queen(2);
        
        // make for other player
       
        
        board[8, 1] = new Rook(1);
        board[8, 8] = new Rook(1);
        board[8, 2] = new Knight(1);
        board[8, 7] = new Knight(1);
        board[8, 3] = new Bishop(1);
        board[8, 6] = new Bishop(1);
        board[8, 5] = new King(1);
        board[8, 4] = new Queen(1);


        
        for(int i = 1 ; i<= 8 ; i++)
        for(int j = 1; j<= 8 ; j++)
            if (board[i, j] is null)
                board[i, j] = new Empty();


    }

}