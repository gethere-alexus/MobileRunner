using System;
public class OnBoostApplied : EventArgs
{
    public readonly Boost Boost;

    public OnBoostApplied(Boost boost)
    {
        Boost = boost;
    }
}
