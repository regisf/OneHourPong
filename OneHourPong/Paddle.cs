using System;
using SFML.Graphics;
using SFML.Window;

namespace OneHourPong
{
	public class Paddle
	{
		public enum Where
		{
			Right,
			Left
		};

		private Vector2f _position = new Vector2f (0, 250);
		private RectangleShape _paddle;
		private Where _where;

		public Paddle (Where where)
		{
			_where = where;
			_position.X = where == Where.Right ? 750 : 50;
			_paddle = new RectangleShape (new Vector2f (10, 100));
			_paddle.FillColor = where == Where.Right ? Color.Blue : Color.Red;

		}

		public void Draw(RenderWindow window)
		{
			window.Draw (_paddle);
		}

		public void Update()
		{
			if (_where == Where.Right) {
				if (Keyboard.IsKeyPressed (Keyboard.Key.Up)) {
					_position.Y -= 5;
				} else if (Keyboard.IsKeyPressed (Keyboard.Key.Down)) {
					_position.Y += 5;
				}
			} else {
				if (Keyboard.IsKeyPressed (Keyboard.Key.A)) {
					_position.Y -= 5;
				} else if (Keyboard.IsKeyPressed (Keyboard.Key.Q)) {
					_position.Y += 5;
				}
			}

			if (_position.Y > 500) {
				_position.Y = 500;
			} else if (_position.Y < 0) {
				_position.Y = 0;
			}
			_paddle.Position = _position;
		}

		public Where ScreenSide {
			get { return _where; }
		}

		public Vector2f Position {
			get { return _paddle.Position; }
		}
	}
}

