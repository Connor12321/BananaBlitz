using BananaBlitz.Controls;
using BananaBlitz.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BananaBlitz
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private State _currentState;
        private State _nextState;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            int displayWidth = _graphics.PreferredBackBufferWidth = 800;
            int displayHeight =_graphics.PreferredBackBufferHeight = 600;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);
            
        }

        protected override void Update(GameTime gameTime)
        {

            if(_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Sets the background colour
            GraphicsDevice.Clear(Color.White);

            _currentState.Draw(gameTime, _spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
