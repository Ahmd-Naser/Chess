using testForChess.Abstract;
using testForChess.Pieces;
using static System.Console;

namespace testForChess.Helpers;

public class PrintAndBuild
{
    public static void BuildBoard(Cell[,] board )
    {
        
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

    private static void printAte(List<Cell> ate1 = null, List<Cell> ate2 = null)
    {

        Write("player1 : ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        foreach (var i in ate1)
        {
            Write($"{i.Symbol} ,");
        }
        Console.ForegroundColor = ConsoleColor.Gray;

        WriteLine();
        
        Write("player2 : ");
        Console.ForegroundColor = ConsoleColor.Black;

        foreach (var i in ate2)
        {
            Write($"{i.Symbol} ,");
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        WriteLine();
    }

    public static void PrintBoard(Cell[,] board , List<Cell> ate1 = null, List<Cell> ate2 = null )
    {
        
        printAte(ate1 , ate2);
        
        
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (board[i, j] is not null)
                {
                    if ( board[i, j].Player == 1) // White piece
                        Console.ForegroundColor = ConsoleColor.Black;
                    else if(board[i,j].Player == 2) // Black piece or empty space
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    
                }
                
                if(board[i,j] is not null && board[i,j].Symbol != 'E')
                    Write($"{board[i,j].Symbol }");
                else 
                    Write(" ");
                
                Console.ForegroundColor = ConsoleColor.Gray;

                Write(" | ");
            }
            
            WriteLine();
            WriteLine("--------------------------------");
            // WriteLine();

        }
        WriteLine();
        //WriteLine();

    }

    public static void PrintRotatedBoard(Cell[,] board , List<Cell> ate1 = null, List<Cell> ate2 = null)
    {
        printAte(ate1 , ate2);
        
        
        for (int i = 9; i >= 0; i-- )
        {
            for (int j = 9; j >= 0; j--)
            {
                
                if (board[i, j] is not null)
                {
                    if ( board[i, j].Player == 1) // White piece
                        Console.ForegroundColor = ConsoleColor.Black;
                    else if(board[i,j].Player == 2) // Black piece or empty space
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    
                }
                
                if(board[i,j] is not null && board[i,j].Symbol != 'E' )
                    Write($"{board[i,j].Symbol }");
                else 
                    Write(" ");
                
                Console.ForegroundColor = ConsoleColor.Gray;

            
                Write(" | ");
            }
            
            WriteLine();
            WriteLine("--------------------------------");
            // WriteLine();

        }
    }


    public static void TestBoard()
    {
        
            // 2D array with Unicode symbols for chess pieces
            string[,] board = new string[8, 8]
            {
                { "♜", "♞", "♝", "♛", "♚", "♝", "♞", "♜" },
                { "♟", "♟", "♟", "♟", "♟", "♟", "♟", "♟" },
                { " ", " ", " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " ", " ", " " },
                { "♙", "♙", "♙", "♙", "♙", "♙", "♙", "♙" },
                { "♖", "♘", "♗", "♕", "♔", "♗", "♘", "♖" }
            };

            Console.OutputEncoding = System.Text.Encoding.UTF8; // Enable UTF-8 encoding

            // Print column labels
            Console.Write("   ");
            for (char col = 'A'; col <= 'H'; col++)
            {
                Console.Write($" {col} ");
            }
            Console.WriteLine();

            // Print the board with row labels and alternating background colors
            for (int row = 0; row < 8; row++)
            {
                Console.Write($" {8 - row} "); // Row label

                for (int col = 0; col < 8; col++)
                {
                    // Set background color for the square
                    if ((row + col) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.DarkGray; // Dark square
                    else
                        Console.BackgroundColor = ConsoleColor.White; // Light square

                    // Set foreground color for pieces
                    if (char.IsUpper(board[row, col][0])) // White piece
                        Console.ForegroundColor = ConsoleColor.Black;
                    else // Black piece or empty space
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.Write($" {board[row, col]} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            // Reset colors
            Console.ResetColor();
        
    }
}