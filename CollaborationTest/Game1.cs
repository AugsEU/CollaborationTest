using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CollaborationTest
{
	public class Game1 : Game
	{
		const float SPEED = 500.0f;
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		Texture2D mIcon;
		Vector2 mVel;
		Vector2 mPos;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			mVel = new Vector2(SPEED, SPEED);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			mIcon = Content.Load<Texture2D>("icon");
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			Rectangle view = GraphicsDevice.Viewport.Bounds;

			if (mIcon.Height + mPos.Y >= view.Height)
			{
				mVel.Y = -SPEED;
			}
			else if(mPos.Y < 0.0f)
			{
				mVel.Y = SPEED;
			}

			if (mIcon.Width + mPos.X >= view.Width)
			{
				mVel.X = -SPEED;
			}
			else if (mPos.X < 0.0f)
			{
				mVel.X = SPEED;
			}

			mPos += mVel * gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Pink);

			_spriteBatch.Begin();
			_spriteBatch.Draw(mIcon, mPos, Color.White);
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}