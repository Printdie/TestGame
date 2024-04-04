using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame;

public class TestGame : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private Texture2D ballSprite;
    private Vector2 ballPosition = new(200, 200);
    private float ballSpeed = 100f;

    public TestGame()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        ballPosition = new(200, 200);
        ballSpeed = 100f;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        ballSprite = Content.Load<Texture2D>("ball");
    }

    protected override void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
            Exit();

        if (keyboardState.IsKeyDown(Keys.Up))
        {
            ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (keyboardState.IsKeyDown(Keys.Down))
        {
            ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (keyboardState.IsKeyDown(Keys.Left))
        {
            ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (keyboardState.IsKeyDown(Keys.Right))
        {
            ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (ballPosition.X > graphics.PreferredBackBufferWidth - ballSprite.Width / 2)
        {
            ballPosition.X = graphics.PreferredBackBufferWidth - ballSprite.Width / 2;
        }
        else if (ballPosition.X < ballSprite.Width / 2)
        {
            ballPosition.X = ballSprite.Width / 2f;
        }

        if (ballPosition.Y > graphics.PreferredBackBufferHeight - ballSprite.Height / 2)
        {
            ballPosition.Y = graphics.PreferredBackBufferHeight - ballSprite.Height / 2;
        }
        else if (ballPosition.Y < ballSprite.Height / 2)
        {
            ballPosition.Y = ballSprite.Height / 2;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();
        spriteBatch.Draw(ballSprite,
            ballPosition,
            null,
            Color.White,
            0f,
            new Vector2(ballSprite.Width / 2f, ballSprite.Height / 2f),
            Vector2.One,
            SpriteEffects.None,
            0f);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}