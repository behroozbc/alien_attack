using Godot;

using System;

public partial class Player : CharacterBody2D
{
	const float SPEED= 4;
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("move_up"))
			Velocity=new (Velocity.X,Velocity.Y-SPEED);
		if (Input.IsActionPressed("move_down"))
			Velocity = new(Velocity.X, Velocity.Y + SPEED);
		if (Input.IsActionPressed("move_right"))
			Velocity = new(Velocity.X + SPEED, Velocity.Y);
		if (Input.IsActionPressed("move_left"))
			Velocity = new(Velocity.X - SPEED, Velocity.Y);
		MoveAndSlide();
		GlobalPosition.Clamp(new(0,0), GetViewportRect().Size);
	}
}
