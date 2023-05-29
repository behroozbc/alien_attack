using Godot;

using System;
using System.Diagnostics;

public partial class Player : CharacterBody2D
{
    [Signal]
    public delegate void TookDamageEventHandler();
    public Player()
    {
        rocket_scene = GD.Load<PackedScene>("res://scenes/rocket.tscn");
        
    }
    const float SPEED = 400;
    private PackedScene rocket_scene;
    private AudioStreamPlayer _rocketShot;
    private Node rocketContainer;

    public override void _Ready()
    {
        rocketContainer = GetNode<Node>("RocketContainer");
        _rocketShot = GetNode<AudioStreamPlayer>("RocketShoted");
        base._Ready();
    }
    public override void _PhysicsProcess(double delta)
    {
        Velocity = new((Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left")) * SPEED,
            (Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up")) * SPEED);
        MoveAndSlide();
        GlobalPosition.Clamp(new(0, 0), GetViewportRect().Size);
    }
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("shoot"))
            _shootRocket();
        base._Process(delta);
    }

    private void _shootRocket()
    {
        var rocket_instance = rocket_scene.Instantiate<Area2D>();

        rocketContainer.AddChild(rocket_instance);
        rocket_instance.GlobalPosition = new(GlobalPosition.X+50, GlobalPosition.Y);
        _rocketShot.Play();
    }
    public void TakeDamage()
    {
        EmitSignal("TookDamage");
    }
    public void Die()
    {
        QueueFree();
    }
}
