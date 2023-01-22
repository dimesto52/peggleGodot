using Godot;
using System;

public class shoot : Node
{

    [Export]
    PackedScene ball;

    //objet a tirer distance de spawn
    [Export]
    public float offset = 1.0f;

    //timer de shoot
    [Export]
    public float fireRate = 1.0f;
    float lastFire = 0.0f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        lastFire = fireRate;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
         //ajour de duré au timer de shoot
        lastFire += delta;

        //verification de touche appuyer et du timer
        if(compterBall.compter.numBall > 0)
            if (Input.IsActionPressed("click"))
                if (lastFire >= fireRate)
                {
                    //remise a zero du timer
                    lastFire = 0;

                    //instansiation de l'objet a tirer
                    Node2D oball = ball.Instance<Node2D>();
                    oball.Position = this.GetParent<Node2D>().Position - (-this.GetParent<Node2D>().GlobalTransform.y) * offset;

                    GetTree().Root.AddChild((Node)oball);

                    
                    compterBall.compter.RemoveBall();

                    ((RigidBody2D)oball).AddForce(Vector2.Zero,(this.GetParent<Node2D>().GlobalTransform.y) * 100);

                    //direction de l'objet a tirer
                    //oball.GetChild<moveball>(0).direction = (this.GetParent<Node2D>().GlobalTransform.y);

                }
    }
}
