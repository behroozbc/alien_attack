using Godot;

using System;
using System.Diagnostics;

public partial class enemy_spawner : Node2D
{
    private PackedScene enemySence;
    [Signal]
    public delegate void EnemySpawnedEventHandler(enemy enemy);
    public override void _Ready()
    {
        enemySence = GD.Load<PackedScene>("res://scenes/enemy.tscn");
        base._Ready();
    }
    public void OnTimerTimeout()
    {
        _SpawnEnemy();
    }

    private void _SpawnEnemy()
    {
        var enemyInstance = enemySence.Instantiate<enemy>();
        
        enemyInstance.Set("Speed", Random.Shared.Next(50, 500));
        enemyInstance.GlobalPosition = new(1350, Random.Shared.Next(20, 700));
        EmitSignal("EnemySpawned", enemyInstance);
        AddChild(enemyInstance);
    }
}
