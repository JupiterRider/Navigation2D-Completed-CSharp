using Godot;
using System.Collections.Generic;

public class Player : Sprite
{
    private const int SPEED = 50;
    public List<Vector2> Path = new List<Vector2>();

    public override void _Process(float delta)
    {
        float distanceToWalk = SPEED * delta;

        while (distanceToWalk > 0 && Path.Count > 0)
        {
            float distanceToNextPoint = Position.DistanceTo(Path[0]);

            if (distanceToWalk <= distanceToNextPoint)
            {
                Position += Position.DirectionTo(Path[0]) * distanceToWalk;
            }
            else
            {
                Position = Path[0];
                Path.Remove(Path[0]);
            }

            distanceToWalk -= distanceToNextPoint;
        }
    }
}