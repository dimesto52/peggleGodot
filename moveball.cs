using Godot;
using System;

public class moveball : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    public Vector2 direction = Vector2.Zero;
    [Export]
    public float speed = 100.0f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Update is called once per frame
    public override void _Process(float delta)
    {

        //mise a jour du mouvement
        this.GetParent<Node2D>().Position += direction * delta * speed; 
    }
}
