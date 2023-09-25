using Microsoft.Xna.Framework;

namespace CardActionGame.Core;

public struct RectBounds
{
    public Vector2 size;
    
    
    public static bool Intersects(ref RectBounds a, ref Transform aTransform, ref RectBounds b, ref Transform bTransform)
    {
        BoundingBox x;
        
        var aSize = a.size * aTransform.scale;
        var bSize = b.size * bTransform.scale;

        var aMin = aTransform.position - aSize * .5f;
        var bMin = bTransform.position - bSize * .5f;
        var aMax = aTransform.position + aSize * .5f;
        var bMax = bTransform.position + bSize * .5f;

        var result = true;
        if ((double) aMax.X >= (double) bMin.X && (double) aMin.X <= (double) bMax.X)
        {
            if ((double) aMax.Y < (double) bMin.Y || (double) aMin.Y > (double) bMax.Y)
                result = false;
        }
        else
            result = false;

        return result;
    }
}

public static class RectBoundFunctions
{
}