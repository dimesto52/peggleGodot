using Godot;
using System;

public class platformDestroy : Node
{
    [Export]
    public float timeToDestroy = 3.0f;
    float timeCount = 0f;

    bool on = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.GetParent().GetChild<Area2D>(3).Connect("body_entered", this,"_on_Area2D_body_entered" );
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(on)
        {
            timeCount+= delta;
            if(timeCount > timeToDestroy)
            {
                Node body = this.GetParent();
                body.GetParent().RemoveChild(body);
                body.Dispose();
            }

        }
    }

    public void  _on_Area2D_body_entered( Node body)
    {
        GD.Print("detect" + this.GetParent().Name);
        if(body.IsClass("RigidBody2D"))
        if(body != GetParent())
        {

                on = true;

            this.GetParent().GetChild<Sprite>(0).Modulate = new Color(0.5f,0.5f,0.5f);
        }
    }

}
