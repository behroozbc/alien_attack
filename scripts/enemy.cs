using Godot;

using System;
using System.Diagnostics;

public partial class enemy : Area2D
{
    [Export]
    public int Speed = 5;
    [Signal]
    public delegate void DiedEventHandler();
    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition = new(GlobalPosition.X - (float)(delta * Speed), GlobalPosition.Y);
        base._PhysicsProcess(delta);
    }
    public void Die()
    {
        QueueFree();
        EmitSignal("Died");
    }
    public void OnBodyEntered(Player player)
    {
        player.TakeDamage();
        Die();
    }
}
