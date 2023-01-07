using Godot;
using System;

public class drawCompterString : Label
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        compterBall.compter.compterChange += UpdateText;
        UpdateText(compterBall.compter.numBall);
      
    }

    void UpdateText(int i)
    {
        Text = "x" + i.ToString();
    }
}
