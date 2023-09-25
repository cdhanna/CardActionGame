using Microsoft.Xna.Framework;

namespace CardActionGame.Core;

public struct Transform
{
    public Vector2 position;
    public Vector2 scale;

    public Transform()
    {
        position = Vector2.Zero;
        scale = Vector2.One;
    }
}

// public static class TransformFunctions
// {
//     public static bool IsOverlap(this Transform a, Transform b)
//     {
//         //var is
//     }
// }
