using Chess.Abstract;

using static Chess.Helpers.MovesValidator;

namespace Chess.Helpers;

public static class AccessablePositions
{


    public static List<Point> GetAllForOnePosition(Point current , int purpose, Cell[,] board)
    {
        if (Chess.Helpers.MovesValidator.OutBounds(current))
            return null;
        
        var accessablePlaces = accessablePoints(current, purpose ,  board);

        return accessablePlaces;
    }
    public static HashSet<Point> GetAll(byte player,int purpose ,  Cell[,] board)
    {
        
        var result = new HashSet<Point>();

        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 8; j++)
            {
                if (board[i, j].Player == player)
                {
                    var accessablePlaces = accessablePoints(new Point(i, j), purpose ,  board);
                    
                    addListToHashSet(accessablePlaces , ref result);
                }
            }
        }

        return result;
    }

    private static void addListToHashSet(List<Point> list, ref HashSet<Point> st)
    {
        foreach (var i in list)
            st.Add(i);
        
    }
    private static List<Point> accessablePoints(Point current ,int purpose , Cell[,] board)
    {
        char symbol = board[current.x, current.y].Symbol;

        return symbol switch
        {
            '♙' => (purpose == (int)Purpose.forThreate) ? PawnForThreate(current , board) : PawnForMove(current , board),
            '♔' => King(current , board),
            '♕' => Queen(current , board),
            '♗' => Bishop(current , board),
            '♘' => Knight(current , board),
            '♖' => Rook(current , board),
            _ => new()
            
        };
    }
    
    public static List<Point> PawnForMove(Point from , Cell[,] board)
    {
        
        byte player = board[from.x, from.y].Player;
        var res = new List<Point>();

        bool used = board[from.x, from.y].Used;
        
        int[] dx;
        int[] dy;

        if (player == 1)
        {
            dx = [-1 , -1 , -1 , -2 ];
            dy = [ 1 , -1 ,  0 ,  0];
            
        }

        else
        {
            dx = [1 , 1 , 1 ,  2 ];
            dy = [1 , -1 , 0 , 0 ];
        }

        for (int i = 0; i < 2; i++)
        {
            int nx = from.x + dx[i];
            int ny = from.y + dy[i];
            
            if(OutBounds(nx,ny) )
                continue;
            
            if(!IsMine(player , board[nx,ny] ) && !IsEmpty(board[nx,ny] ) )
                res.Add(new(nx,ny) );
        }

        for (int i = 2; i < 4; i++)
        {
            int nx = from.x + dx[i];
            int ny = from.y + dy[i];

            if(OutBounds(nx,ny) )
                continue;
            
            if (i == 3 && used)
                break;

            if (IsEmpty(board[nx, ny]))
                res.Add(new(nx, ny));
            else
                break;

        }
        
        
        return res;
    }

    public static List<Point> PawnForThreate(Point from , Cell[,] board)
    {
        int[] dx = new int[] { -1 , -1 , 1 , 1 };
        int[] dy = new int[] { 1 , -1 ,  1 , -1 };
        var res = new List<Point>();    
        //res.Add(from);


        int start = 0, end = 0;

        byte player = board[from.x, from.y].Player;
        
        if (player == 1)
        {
            start = 0;
            end = 1;
        }
        else if (player == 2)
        {
            start = 2;
            end = 3;
        }
        
        for (int i = start; i <= end; i++)
        {
            int nx = from.x + dx[i], ny = from.y + dy[i];
            
            if(!OutBounds(nx , ny) && IsEmpty(board[nx, ny] ) )
                res.Add(new Point(nx,ny) );
        }

        return res;
    }
    
    public static List<Point> King(Point from, Cell[,] board)
    {
        int[] dx = new int[] { 1 , 1 , 1 , 0 , 0 , -1 , -1 , -1 };
        int[] dy = new int[] { 1 , 0 , -1 , 1 , -1 , 1 , 0 , -1 };
        
        var res = new List<Point>();
        //res.Add(from);

        for (int i = 0; i < 8; i++)
        {
            int nx = from.x + dx[i], ny = from.y + dy[i];
            
            if(!OutBounds( nx , ny ) && !IsMine( board[from.x , from.y].Player , board[nx,ny] ) )
                res.Add(new (nx , ny) );
            
        }
        
        return res;
    }
    
    public static List<Point> Queen(Point from, Cell[,] board)
    {
        int[] dx = new int[] { 1 , 1 , 1 , 0 , 0 , -1 , -1 , -1 };
        int[] dy = new int[] { 1 , 0 , -1 , 1 , -1 , 1 , 0 , -1 };
        var res = new List<Point>();
        //res.Add(from);

        byte player = board[from.x, from.y].Player;
        
        for (int i = 0; i < 8; i++)
        {

            int nx = from.x + dx[i], ny = from.y + dy[i] ;
            
            while (!OutBounds(nx, ny)   )
            {
                if (IsMine(player , board[nx, ny]) )
                    break;
                
                res.Add(new(nx , ny) );
                
                if (!IsMine(player , board[nx, ny]) && !IsEmpty(board[nx,ny] ) )
                    break;

                nx += dx[i];
                ny += dy[i];
                
            }
            
        }
        
        return res;
    }
    
    public static List<Point> Bishop(Point from, Cell[,] board)
    {
        int[] dx = new int[] { 1 , 1 , -1 , -1 };
        int[] dy = new int[] { 1 , -1 , 1 , -1 };
        
        var res = new List<Point>();
        //res.Add(from);

        byte player = board[from.x, from.y].Player;

        for (int i = 0; i < 4; i++)
        {

            int nx = from.x + dx[i], ny = from.y + dy[i] ;
            
            while (!OutBounds(nx, ny)   )
            {
                if (IsMine(player , board[nx, ny]) )
                    break;
                
                res.Add(new(nx , ny) );
                
                if (!IsMine(player , board[nx, ny]) && !IsEmpty(board[nx,ny] ))
                    break;

                nx += dx[i];
                ny += dy[i];
            }
            
        }
        
        return res;
    }
    
    public static List<Point> Knight(Point from, Cell[,] board)
    {
        int[] dx = new int[] { 1 , 1 , -1 , -1 , 2 , 2 , -2 , -2};
        int[] dy = new int[] { 2 , -2 , 2 , -2 , 1 , -1 , 1 , -1 };
        
        var res = new List<Point>();
        //res.Add(from);


        for (int i = 0; i < 8; i++)
        {
            int nx = from.x + dx[i], ny = from.y + dy[i];
            
            if(!OutBounds( nx , ny ) && !IsMine( board[from.x , from.y].Player , board[nx,ny] ) )
                res.Add(new (nx , ny) );
            
        }
        return res;
    }
    
    public static List<Point> Rook(Point from, Cell[,] board)
    {
        int[] dx = new int[] { 1, -1, 0, 0 };
        int[] dy = new int[] { 0 , 0 , 1 , -1 };
        
        byte player = board[from.x, from.y].Player;

        var res = new List<Point>();
       // res.Add(from);

        
        for (int i = 0; i < 4; i++)
        {

            int nx = from.x + dx[i], ny = from.y + dy[i] ;
            
            while (!OutBounds(nx, ny)   )
            {
                if (IsMine(player , board[nx, ny]) )
                    break;
                
                res.Add(new(nx , ny) );
                
                if (!IsMine(player , board[nx, ny]) && !IsEmpty(board[nx,ny] ))
                    break;

                nx += dx[i];
                ny += dy[i];
            }
            
        }
        
        return res;
    }
    
}