using testForChess.Abstract;

namespace testForChess.Interfaces;

public interface Move
{
    bool Move(Point from, Point to, Cell[,] board , List<Cell> ate1 , List<Cell> ate2);
}