using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace onebadone;

public class Game1 : Game
{
    Texture2D bolaTexture;
    Vector2 bolaPosition;
    float bolaSpeed;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

   

    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        bolaPosition = new Vector2(_graphics.PreferredBackBufferWidth /2 
                                    ,_graphics.PreferredBackBufferHeight/2);

        bolaSpeed = 100f;
        
        base.Initialize();                       
    }
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        bolaTexture = Content.Load<Texture2D>("bolas");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        


        // TODO: Add your update logic here
        
        //time since u was called last
            float updateBolaSpeed = bolaSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            var kstate = Keyboard.GetState();

            if(kstate.IsKeyDown(Keys.Up)){
                bolaPosition.Y -= updateBolaSpeed;
            }
            if(kstate.IsKeyDown(Keys.Right)){
                bolaPosition.X += updateBolaSpeed;
            }
            if(kstate.IsKeyDown(Keys.Down)){
                bolaPosition.Y += updateBolaSpeed;
            }
            if(kstate.IsKeyDown(Keys.Left)){
                bolaPosition.X -= updateBolaSpeed;
            }
        //end
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();
        _spriteBatch.Draw(bolaTexture,
                        bolaPosition ,
                        null,
                        Color.White,
                        0f,
                        new Vector2(bolaTexture.Width / 2, bolaTexture.Height/2),
                        Vector2.One,
                        SpriteEffects.None,
                        0f);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
