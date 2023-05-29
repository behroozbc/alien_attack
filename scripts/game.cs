using Godot;

using System;
using System.Diagnostics;

public partial class game : Node2D
{
    [Export]
    public uint Lives = 3;
    private uint Score = 0;
    private PackedScene _gameOverSence;
    private Player _player;
    private hud _hud;
    private CanvasLayer _ui;
    private AudioStreamPlayer _enemyHitSound;
    private AudioStreamPlayer _playerTookDamage;

    public override void _Ready()
    {
        _gameOverSence = GD.Load<PackedScene>("res://scenes/game_over_screen.tscn");
        _player = GetNode<Player>("Player");
        _hud = GetNode<hud>("UI/HUD");
        _ui = GetNode<CanvasLayer>("UI");
        _enemyHitSound = GetNode<AudioStreamPlayer>("EnemyHitSound");
        _playerTookDamage = GetNode<AudioStreamPlayer>("PlayerTookDamage");
        _hud.SetScore(Score);
        base._Ready();
    }
    public void OnDeathzoneAreaEntered(enemy enemy)
    {
        enemy.QueueFree();
    }

    public void OnPlayerTookDamage()
    {
        Lives--;
        _hud.SetLives(Lives);
        _playerTookDamage.Play();
        if (Lives == 0)
        {
            _player.Die();
            var gameover= _gameOverSence.Instantiate<game_over_screen>();
            _ui.AddChild(gameover);
            gameover.SetScore(Score);
        }
    }
    public void OnEnemySpawnerEnemySpawned(enemy enemy)
    {
        enemy.Died += OnEmenyDied;
    }
    public void OnEmenyDied()
    {
        Score += 100;
        _enemyHitSound.Play();
        _hud.SetScore(Score);
    }
}
