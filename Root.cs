using Godot;
using System.Collections.Generic;

public class Root : Node2D
{
    private Navigation2D navigation2D;
    private Player player;
    private Line2D line2D;

    public override void _Ready()
    {
        navigation2D = GetNode<Navigation2D>("Navigation2D");
        player = GetNode<Player>("Player");
        line2D = GetNode<Line2D>("Line2D");
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton)
        {
            if ((@event as InputEventMouseButton).ButtonIndex == 1 && (@event as InputEventMouseButton).Pressed)
            {
                Vector2[] path = navigation2D.GetSimplePath(player.Position, (@event as InputEventMouseButton).Position);
                line2D.Points = path;
                player.Path = new List<Vector2>(path);
            }
        }
    }
}