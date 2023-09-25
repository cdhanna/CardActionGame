using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardActionGame.Core;

public struct Sprite
{
    public Texture2D texture;
    public Color color;
    public Vector2 size;

    public Sprite()
    {
        color = Color.White;
        texture = Game1.pixel;
        size = Vector2.One;
    }
}

public static class SpriteFunctions
{
    public static void Draw(this ref Sprite sprite, ref Transform transform, SpriteBatch sb)
    {
        var size = sprite.size * transform.scale;
        var dest = new Rectangle(
            (int)(transform.position.X - size.X * .5f),
            (int)(transform.position.Y - size.Y * .5f),
            (int)size.X,
            (int)size.Y);

        sb.Draw(sprite.texture, dest, sprite.color);
    }
}