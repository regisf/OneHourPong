/*
 * One Hour Pong Game 
 * (c) Régis FLORET 2024 and later
 * Date: 22/11/2014
 * Time: 18:09
 * 
 */
using System;

using SFML.Graphics;
using SFML.Window;

namespace OneHourPong
{
	/// <summary>
	/// This is the main game class. handle event and so on.
	/// </summary>
	public class Game
	{
		private RenderWindow window;
		private Paddle leftPaddle;
		private Paddle rightPaddle;
		private Ball ball;
		private Score _score;
		private bool _pause = false;
		private Text _pauseText;
		private StartScene _startScene;

		/// <summary>
		/// Create SFML window, connect event, create game objects.
		/// </summary>
		public Game()
		{
			// Create the render window
			window = new RenderWindow (new VideoMode (800, 600), "One hour pong");
			window.SetFramerateLimit (60);
			window.SetKeyRepeatEnabled (true);
			window.SetVerticalSyncEnabled (true);

			// Connect event to methods
			window.Closed += window_Closed;
			window.KeyReleased += HandleKeyReleased;

			// Create objects
			leftPaddle = new Paddle (Paddle.Where.Left);
			rightPaddle = new Paddle (Paddle.Where.Right); 	 
			_score = new Score ();

			ball = new Ball ();
			ball.BallLosted += HandleBallLosted;

			_pauseText = new Text("Pause", new SFML.Graphics.Font ("Data/Square.ttf"), 100);
			_pauseText.Position = new Vector2f (
				(800 - _pauseText.GetLocalBounds ().Width) / 2f, 
				(600 - _pauseText.GetLocalBounds ().Height) / 2f
			);
			Playing = false;
			_startScene = new StartScene ();
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="OneHourPong.Game"/> is playing.
		/// </summary>
		/// <value><c>true</c> if playing; otherwise, <c>false</c>.</value>
		public bool Playing {
			get;set;
		}

		/// <summary>
		/// Handles the ball losted.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void HandleBallLosted (object sender, BallLostEventArgs e)
		{
			if (e.Side == Paddle.Where.Right) {
				_score.UpdateLeft ();
			} else if (e.Side == Paddle.Where.Left) {
				_score.UpdateRight ();
			} 
			ball.Reset ();
		}

		/// <summary>
		/// Handles the key released.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void HandleKeyReleased (object sender, KeyEventArgs e)
		{
			if (!Playing) {
				Playing = true;
			} else if (e.Code == Keyboard.Key.P) {
				_pause = !_pause;
			} else if (e.Code == Keyboard.Key.Escape && Playing == true) {
				Playing = false;
			}
		}

		/// <summary>
		/// Run the game
		/// </summary>
		public void Run() 
		{
			while (window.IsOpen())
			{
				window.DispatchEvents();
				window.Clear();

				if (Playing) {
					// Do game stuff
					if (!_pause) {
						leftPaddle.Update ();
						rightPaddle.Update ();
						ball.Collide (leftPaddle);
						ball.Collide (rightPaddle);
						ball.Update ();
					} else {
						window.Draw (_pauseText);
					}

					_score.Draw (window);		
					leftPaddle.Draw (window);
					rightPaddle.Draw (window);
					ball.Draw (window);
				} else {
					// Display start panel
					_startScene.Draw (window);
				}

				window.Display();
			}
		}

		/// <summary>
		/// Close the window. This will ends the game.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void window_Closed(object sender, EventArgs e)
		{
			window.Close();
		}
	}
}
