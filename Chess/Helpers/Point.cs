namespace Chess.Helpers;

public class Point
{
    public int x;
    public int y;

    public Point()
    {
        x = y = -1;
    }

    public Point(string[] line)
    {
        x = int.Parse(line[0]);

        y = line[1][0] - 'a' + 1;
    }
}