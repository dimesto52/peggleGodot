using Godot;
using System;

public class bucketMove : Node
{
    [Export]
    public float speed = 100.0f;
    [Export]
    public float min = -100.0f;
    [Export]
    public float max = 100.0f;

    bool doRight = true;

    public override void _Ready()
    {
    }

    public override void _Process(float delta)
    {

            Node2D transform = this.GetParent<Node2D>();
            if (doRight)
            {
                transform.Position += Vector2.Right * delta * speed;
                if (transform.Position.x > max)
                {
                    transform.Position = new Vector2(max, transform.Position.y);
                    doRight = !doRight;
                }
            }
            else
            {
                transform.Position -= Vector2.Right * delta * speed;
                if (transform.Position.x < min)
                {
                    transform.Position = new Vector2(min, transform.Position.y);
                    doRight = !doRight;
                }
            }
    }
}
