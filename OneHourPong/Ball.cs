using System;
using SFML.Graphics;
using SFML.Window;

namespace OneHourPong
{
	public class Ball
	{
		private CircleShape _ball;
		private Vector2f _direction = new Vector2f();
		private Vector2f _position = new Vector2f (395, 295);

		public Ball ()
		{
			_ball = new CircleShape (5);
			_ball.FillColor = Color.White;
			_ball.Position = _position;
			_direction.X = -1;
			_direction.Y = 1;
		}

		public void Draw(RenderWindow window)
		{
			_ball.Position = _position;
			window.Draw (_ball);
		}

		public void Update()
		{
			_position.X += _direction.X * 3;
			_position.Y += _direction.Y * 3;
			if (_position.Y <= 0) {
				_position.Y = 0;
				_direction.Y *= -1;
			} else if (_position.Y >= 590) {
				_position.Y = 590;
				_direction.Y *= -1;
			}
		}

		public void Collide(Paddle paddle)
		{
			// Nothing to do 
			if (_position.X > 55 && _position.X < 740) {
				return;
			}

			if (_position.Y > paddle.Position.Y && _position.Y < paddle.Position.Y + 100) {
				if (paddle.ScreenSide == Paddle.Where.Left && _direction.X == -1) {
					if (paddle.Position.X + 10 >= _position.X) {
						_direction.X = 1;
						_position.X = paddle.Position.X + 10;
					}
				} else if (paddle.ScreenSide == Paddle.Where.Right && _direction.X == 1) {
					if (paddle.Position.X <= _position.X + 10) {
						_direction.X = -1;
						_position.X = paddle.Position.X;
					}
				}
			}

		}
	}
}

