/*
 * Created by SharpDevelop.
 * User: Regis
 * Date: 22/11/2014
 * Time: 18:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using SFML.Graphics;
using SFML.Window;

namespace OneHourPong
{
	/// <summary>
	/// Description of Game.
	/// </summary>
	public class Game
	{
		private RenderWindow window;
		private Paddle leftPaddle;
		private Paddle rightPaddle;
		private Ball ball;

		public Game()
		{
			// Create the render window
			window = new RenderWindow (new VideoMode (800, 600), "One hour pong");
			window.SetFramerateLimit (60);
			window.SetKeyRepeatEnabled(true);

			// Connect event to methods
			window.Closed += window_Closed;

			// Create objects
			leftPaddle = new Paddle (Paddle.Where.Left);
			rightPaddle = new Paddle (Paddle.Where.Right);
			ball = new Ball ();
		}

		public void Run() 
		{
			while (window.IsOpen())
			{
				window.DispatchEvents();
				window.Clear();

				leftPaddle.Update ();
				rightPaddle.Update ();
				ball.Collide (leftPaddle);
				ball.Collide (rightPaddle);
				ball.Update ();

				leftPaddle.Draw (window);
				rightPaddle.Draw (window);
				ball.Draw (window);

				window.Display();
			}
		}

		void window_Closed(object sender, EventArgs e)
		{
			window.Close();
		}
	}
}
