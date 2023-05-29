using Godot;
using System;
using System.Diagnostics;

public partial class game_over_screen : Control
{
    private Label _score;

    public override void _Ready()
    {
        _score = GetNode<Label>("Panel/ScoreVal");
        Debug.WriteLine(_score.Text);
        base._Ready();
    }
    public void OnButtonPressed()
    {
        GetTree().ReloadCurrentScene();
    }
    public void SetScore(uint score)
    {
        _score.Text = score.ToString();
    }
}
