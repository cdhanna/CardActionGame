using CardActionGame.Core;
using Microsoft.Xna.Framework;

namespace CardActionGame.Player;

public struct PlayerEntity
{
    public Transform transform;
    public Sprite sprite;
    public RectBounds bounds;
    public Vector2 velocity;
    public float drag;
    public float speed;
}