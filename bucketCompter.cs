using Godot;
using System;

public class bucketCompter : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void _on_Area2D_body_entered(Node body)
    {
        compterBall.compter.AddBall();

        this.GetTree().Root.RemoveChild(body);
        body.Dispose();
        GD.Print("bucket");
    }
}
