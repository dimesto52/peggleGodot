using Godot;
using System;

public class detectWinLose : Node
{
    [Export]
    public string WinUiRef;//uiWinLose/WinUI
    public Control WinUi
    {
        get
        {
            return this.GetNode<Control>(WinUiRef);
        }
    }

    [Export]
    public string LoseUiRef;
    public Control LoseUi
    {
        get
        {
            return this.GetNode<Control>(LoseUiRef);
        }
    }

    // Start is called before the first frame update
    public override void _Ready()
    {

        leftPlatformCount.countChange += platformcountChange;
        onBoardBallCount.countChange += ballcountChange;
    }


    void platformcountChange(int platformcount)
    {
        if (platformcount == 0)
        {
            WinUi.Visible = (true);
        }
    }
    void ballcountChange()
    {
        GD.Print("ballcountChange" +
         "WinUi.Visible : " + WinUi.Visible +
          "compterBall.compter.numBall  : " + compterBall.compter.numBall +
           "platformDestroy.waitDestroy : " + platformDestroy.waitDestroy );
        if(WinUi.Visible != true)
        if(compterBall.compter.numBall <= 0 && platformDestroy.waitDestroy <= 0)
            LoseUi.Visible = (true);
    }

    public void _on_Button_pressed()
    {
        leftPlatformCount.countChange -= platformcountChange;
        onBoardBallCount.countChange -= ballcountChange;

        compterBall.compter.numBall = 5;

        this.GetTree().ReloadCurrentScene();

    }
}
