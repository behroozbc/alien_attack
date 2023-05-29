using Godot;
using System;

public partial class  hud : Control
{
    private Label _scoreLbl;
    private Label _livesLbl;

    public override void _Ready()
    {
        _scoreLbl = GetNode<Label>("Score");
        _livesLbl = GetNode<Label>("Lives");
        base._Ready();
    }
    public void SetScore(uint score)
    {
        _scoreLbl.Text = score.ToString();
    }
    public void SetLives(uint lives)
    {
        _livesLbl.Text = lives.ToString();
    }
}
