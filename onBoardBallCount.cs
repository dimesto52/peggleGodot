using Godot;
using System;

public class onBoardBallCount : Node
{
    private static int count = 0;
    public static int Count
    {
        get { return count; }
        set
        {
            if(value <=0) 
            {
                platformDestroy.waitDestroy = 0;
                countChange?.Invoke();
            }
            count = value;
        }
    }
    public static Action countChange;

    public override void _Ready()
    {
        onBoardBallCount.Count++;
        this.Connect("tree_exited", this,"_on_exited" );
    }
    
    private void _on_exited()
    {
        onBoardBallCount.Count--;
    }

}
