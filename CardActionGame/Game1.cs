using CardActionGame.Core;
using CardActionGame.Enemy;
using CardActionGame.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CardActionGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public World world;

    public static Texture2D pixel;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);


        pixel = new Texture2D(GraphicsDevice, 1, 1);
        pixel.SetData(new Color[]{Color.White});
        
        world = new World
        {
            spriteBatch = _spriteBatch,
            pixel = pixel
        };

        world.player = new PlayerEntity
        {
            sprite = new Sprite
            {
                size = new Vector2(100,100)
            },
            transform = new Transform
            {
                position = new Vector2(100, 200),
            },
            bounds = new RectBounds
            {
                size = new Vector2(100,100)
            },
            drag = .1f,
            speed = .1f
        };

        for (var i = 0; i < 1000; i++)
        {


            world.AddEnemy(new EnemyEntity
            {
                transform = new Transform
                {
                    position = new Vector2(30, 40 + i*12)
                },
                sprite = new Sprite
                {
                    color = Color.Beige,
                    size = new Vector2(50, 10)
                },
                bounds = new RectBounds
                {
                    size = new Vector2(50, 10)
                }
            });
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        world.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        world.Draw(gameTime);
        base.Draw(gameTime);
    }
}
