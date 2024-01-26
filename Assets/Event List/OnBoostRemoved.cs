using System;

public class OnBoostRemoved : EventArgs
{
    public Boost Boost;

    public OnBoostRemoved(Boost boost)
    {
        Boost = boost;
    }
}
