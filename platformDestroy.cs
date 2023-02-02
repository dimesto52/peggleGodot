using Godot;
using System;

public class platformDestroy : Node
{
    [Export]
    public float timeToDestroy = 3.0f;
    float timeCount = 0f;
    bool on = false;

    public static int waitDestroy = 0;

    public override void _Ready()
    {
        this.GetParent().GetChild<Area2D>(3).Connect("body_entered", this,"_on_Area2D_body_entered" );
        this.Connect("tree_exited", this,"_on_exited" );
    }

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

    void ballcountChange()
    {
        if (this != null)
        {
            if(this.GetParent() != null)
            {
                    Node body = this.GetParent();
                if(body.GetParent() != null)
                {
                    body.GetParent().RemoveChild(body);
                    body.Dispose();
                }
            }
        }
    }

    public void  _on_Area2D_body_entered( Node body)
    {
        //GD.Print("detect" + this.GetParent().Name);
        if(!on)
        if(body.IsClass("RigidBody2D"))
        if(body != GetParent())
        {

                on = true;

            this.GetParent().GetChild<Sprite>(0).Modulate = new Color(0.5f,0.5f,0.5f);

                onBoardBallCount.countChange += ballcountChange;

                waitDestroy++;
        }
    }

    private void _on_exited()
    {
        waitDestroy--;
        onBoardBallCount.countChange -= ballcountChange;
    }

}
