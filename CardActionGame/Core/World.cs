using System.Collections.Generic;
using System.Xml;
using CardActionGame.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardActionGame.Core;



public partial class World
{

    public SpriteBatch spriteBatch;
    public Texture2D pixel;
    
    public void Update(GameTime gt)
    {
        UpdateEnemies(gt);
        UpdatePlayer(gt);
    }

    public void Draw(GameTime gameTime)
    {
       DrawEnemies();
       DrawPlayer();
    }
}