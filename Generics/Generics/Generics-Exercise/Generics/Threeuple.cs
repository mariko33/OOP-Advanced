
public class Threeuple<TFirst, TSecond, TThird>
{
    public Threeuple(TFirst item1, TSecond item2, TThird item3)
    {
        this.Item1 = item1;
        this.Item2 = item2;
        this.Item3 = item3;
    }

    public TFirst Item1 { get; }
    public TSecond Item2 { get; }
    public TThird Item3 { get; }


    public override string ToString()
    {
        return $"{Item1} -> {Item2} -> {Item3}";
    }
}

