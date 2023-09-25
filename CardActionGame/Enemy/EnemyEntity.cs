using CardActionGame.Core;
using Microsoft.Xna.Framework;

namespace CardActionGame.Enemy;

public struct EnemyEntity
{
    public int eId;
    public Transform transform;
    public Sprite sprite;
    public RectBounds bounds;
    public bool isColliding;
}
