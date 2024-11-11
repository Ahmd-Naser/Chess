namespace Chess.Abstract;

public abstract class Cell
{
    public char Symbol;
    public byte Player { get; set; } = 11;

}