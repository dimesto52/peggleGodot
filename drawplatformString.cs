using Godot;
using System;

public class drawplatformString : Label
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";


    public override void _Ready()
    {

        leftPlatformCount.countChange += UpdateText;
        UpdateText(leftPlatformCount.Count);

        this.Connect("tree_exited", this,"_on_exited" );
      
    }

    void UpdateText(int i)
    {
        Text = "x" + i.ToString();
    }
    
    private void _on_exited()
    {
        leftPlatformCount.countChange -= UpdateText;
        this.Disconnect("tree_exited", this,"_on_exited" );
    }
}
