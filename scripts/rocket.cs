using Godot;

using System;
using System.Diagnostics;

public partial class rocket : Area2D
{
    [Export]
    public int Speed = 300;
    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition = new(GlobalPosition.X + (float)(Speed * delta), GlobalPosition.Y);
        base._PhysicsProcess(delta);
    }
    public void OnVisibleNotifierScreenExited()
    {
        QueueFree();
    }
    public void OnAreaEntered(enemy area)
    {
        if (area.IsInGroup("enemy"))
        {
            area.Die();
            QueueFree();
        }

    }
}
