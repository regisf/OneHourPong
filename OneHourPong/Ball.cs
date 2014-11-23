using System;
using SFML.Graphics;
using SFML.Window;

namespace OneHourPong
{
	public class BallLostEventArgs : EventArgs 
	{
		public BallLostEventArgs(Paddle.Where w) {
			Side = w;
		}

		public Paddle.Where Side {
			get;
			set;
		}
	}

	public delegate void BallLostEventHandler(object sender, BallLostEventArgs e);

	public class Ball
	{
		const uint SpeedIncrease = 1;
		private CircleShape _ball;
		private Vector2f _direction = new Vector2f();
		private Vector2f _position = new Vector2f (395, 295);
		private uint _speed = 3;
		private uint _bumpCount = 0;
		public event BallLostEventHandler BallLosted;

		public Ball ()
		{
			_ball = new CircleShape (5);
			_ball.FillColor = Color.White;
			_ball.Position = _position;
			_direction.X = -1;
			_direction.Y = 1;
		}

		protected virtual void OnBallLosted(BallLostEventArgs e)
		{
			if (BallLosted != null) {
				BallLosted (this, e);
			}
		}

		public void Draw(RenderWindow window)
		{
			_ball.Position = _position;
			window.Draw (_ball);
		}

		public void Update()
		{
			_position.X += _direction.X * _speed;
			_position.Y += _direction.Y * _speed;

			if (_position.X < 45) {
				OnBallLosted (new BallLostEventArgs (Paddle.Where.Right));
				return;
			} else if (_position.X > 770) {
				OnBallLosted (new BallLostEventArgs (Paddle.Where.Left));
				return;
			}

			if (_position.Y <= 0) {
				_position.Y = 0;
				_bumpCount++;
				_direction.Y *= -1;
			} else if (_position.Y >= 590) {
				_position.Y = 590;
				_direction.Y *= -1;
				_bumpCount++;
			}

			if (_bumpCount > 10) {
				_bumpCount = 0;
			}

			if (_bumpCount == 10) {
				_speed += SpeedIncrease;
				_bumpCount = 0;
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
						_bumpCount++;
					}
				} else if (paddle.ScreenSide == Paddle.Where.Right && _direction.X == 1) {
					if (paddle.Position.X <= _position.X + 10) {
						_direction.X = -1;
						_position.X = paddle.Position.X;
						_bumpCount++;
					}
				}
			}
		}

		public void Reset()
		{
			_speed = 3;
			_position.X = 400;
			_position.Y = 300;
			_ball.Position = _position;
		}
	}
}

