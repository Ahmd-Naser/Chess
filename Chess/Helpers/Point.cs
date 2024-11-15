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

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object obj)
    {
        if (obj is Point other)
        {
            return this.x == other.x &&
                   this.y == other.y;
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        // Combine hash codes of properties to ensure unique hash for unique data
        return HashCode.Combine(x, y);
    }
}