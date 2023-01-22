using Godot;
using System;

public class outball : Area2D
{
    public override void _Ready()
    {
        
    }

    public void _on_Area2D_body_entered(Node body)
    {
        if(body.IsClass("RigidBody2D"))
        {
        this.GetTree().Root.RemoveChild(body);
        body.Dispose();
        GD.Print("destroy");
        }
    }
}
