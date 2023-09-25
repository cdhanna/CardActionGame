using CardActionGame.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CardActionGame.Core;

public partial class World
{
    public PlayerEntity player;
    
    void UpdatePlayer(GameTime gt)
    {
        var ks = Keyboard.GetState();

        var acceleration = Vector2.Zero;
        
        if (ks.IsKeyDown(Keys.A))
        {
            acceleration -= Vector2.UnitX;
        }
        if (ks.IsKeyDown(Keys.D))
        {
            acceleration += Vector2.UnitX;
        }
        if (ks.IsKeyDown(Keys.W))
        {
            acceleration -= Vector2.UnitY;
        }
        if (ks.IsKeyDown(Keys.S))
        {
            acceleration += Vector2.UnitY;
        }

        player.velocity *= (1 - player.drag);
        player.velocity += player.speed * acceleration * gt.ElapsedGameTime.Milliseconds;
        player.transform.position += player.velocity;
    }

    void DrawPlayer()
    {
        spriteBatch.Begin();
        player.sprite.Draw(ref player.transform, spriteBatch);
        spriteBatch.End();
    }
}