using Godot;
using System;

public class leftPlatformCount : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        leftPlatformCount.Count++;
        this.GetParent().Connect("tree_exited", this,"_on_exited" );
    }

    private static int count = 0;
    public static int Count
    {
        get { return count; }
        set 
        {
            countChange?.Invoke(value);
            count = value; 
        }
    }

    public static Action<int> countChange;
    private void _on_exited()
    {
        leftPlatformCount.Count--;
        this.GetParent().Disconnect("tree_exited", this,"_on_exited" );
    }
}
