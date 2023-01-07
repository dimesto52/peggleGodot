using System.Collections;
using System.Collections.Generic;

using System;

public class compterBall
{
    public static compterBall compter = new compterBall();

    int balls = 5;

    public Action<int> compterChange;

    public int numBall
    {
        get { return balls; }
        set 
        {
            balls = value;
            compterChange?.Invoke(numBall);
        }
    }

    public void AddBall()
    {
        balls++;
        compterChange?.Invoke(numBall);
    }
    public void RemoveBall()
    {
        balls--;
        compterChange?.Invoke(numBall);
    }

}
