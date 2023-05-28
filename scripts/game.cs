using Godot;

using System;
using System.Diagnostics;

public partial class game : Node2D
{
    [Export]
    public uint Lives = 3;
    private uint Score = 0;
    private Player _player;

    public override void _Ready()
    {
        _player = GetNode<Player>("Player");
        base._Ready();
    }
    public void OnDeathzoneAreaEntered(enemy enemy)
    {
        enemy.Die();
    }

    public void OnPlayerTookDamage()
    {
        Lives--;
        if (Lives == 0)
        {
            _player.Die();
        }
    }
    public void OnEnemySpawnerEnemySpawned(enemy enemy)
    {
        enemy.Died += OnEmenyDied;
    }
    public void OnEmenyDied()
    {
        Score += 100;
        Debug.WriteLine(Score);
    }
}
