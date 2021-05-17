using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BananaBlitz.Controls
{
    public class Button : Components
    {

        #region Fields

        private MouseState _currentMouse;
        private MouseState _previousMouse;

        private SpriteFont _font;

        private bool _isHovering;

        private Texture2D _texture;

        #endregion

        #region Properties

        public event EventHandler Click;
        public  bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        //Determines if the mouse is on top of a button
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle ((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public string Text { get; set; }

        #endregion

        #region Methods

        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            var colour = Color.White;

            //If the mouse hovers over the button, it turns gray
            if (_isHovering)
                colour = Color.Gray;

            _spriteBatch.Draw(_texture, Rectangle, colour);

            //Checks to see if the text is empty, if it's not it centres the text
            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                _spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;
                
                //When the mouse if both hovering over a button and the left mouse button has been pressed, the button is 'clicked'
                if(_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            } 
                
        }

        #endregion

    }
}
