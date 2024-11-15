using Chess.Abstract;
using static Chess.Helpers.Operations;
using static Chess.Shared.Enums.PieceSymbol;

namespace Chess.Helpers;

public class GenerateValidMoves
{
    public static HashSet<Tuple<Point, Point>> ValidMovesInTurn(byte player, Cell[,] board)
    {
        HashSet<Tuple<Point, Point>> result = new();

        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 8; j++)
            {
                if (board[i, j].Player != player)
                    continue;
                
                
                var current = new Point(i, j);
                
                var accessableMoves = AccessablePositions.GetAllForOnePosition( current , (int)Purpose.forMove, board);

                if (accessableMoves.Count > 0)
                {
                    var validMovesList = validMoves(current, accessableMoves , board);
                    addValidMovesToAnswer(current, validMovesList, result);
                    
                }
                
            }
        }

        return result;
    }

    private static void addValidMovesToAnswer(Point from, List<Point> validMoves, HashSet<Tuple<Point, Point>> result)
    {
        foreach (var i in validMoves)
        {
            Tuple<Point, Point> cur = new(from, i);
            result.Add(cur);
        }
    }

    private static List<Point> validMoves(Point from, List<Point> accessableMoves , Cell[,] board)
    {
        byte player = board[from.x, from.y].Player;
        byte otherPlayer = (byte)(3 - player);

        List<Point> ans = new();
        
        foreach (var i in accessableMoves)
        {
            Swap(from , i , board);
            
            Point myKingPosition = getKingPosition(player, board);

            var ThreatedPlaces = AccessablePositions.GetAll(otherPlayer, (int) Purpose.forThreate, board);
            
            if (!ThreatedPlaces.Contains(myKingPosition))
            {
                ans.Add(i);
            }
            
            Swap(from , i , board);

        }
        
        return ans;
    }

    private static Point getKingPosition(byte player, Cell[,] board)
    {
        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 8; j++)
            {
                if (board[i, j].Symbol == (char)PieceSymbol.King)
                    return new(i, j);
                
            }
        }

        return new();
    }
}