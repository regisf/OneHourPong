using System;
using SFML.Graphics;

namespace OneHourPong
{
	public class Score
	{
		private uint _left = 0;
		private uint _right = 0;
		private Text _rightText;
		private Text _leftText;

		public Score()
		{
			_rightText = new Text (String.Format("{0}", _right), new SFML.Graphics.Font("Data/Square.ttf"), 100);
			_rightText.Position = new SFML.Window.Vector2f ((400 -_rightText.GetLocalBounds().Width) / 2f, 0);

			_leftText = new Text (String.Format ("{0}", _left), new SFML.Graphics.Font ("Data/Square.ttf"), 100);
			_leftText.Position = new SFML.Window.Vector2f ((400 -_leftText.GetLocalBounds().Width) / 2f + 400f, 0);
		}

		public void Draw(RenderWindow window)
		{
			window.Draw (_leftText);
			window.Draw (_rightText);
		}

		public void UpdateLeft()
		{
			_left++;
			_leftText.DisplayedString = String.Format ("{0}", _left);
			_leftText.Position = new SFML.Window.Vector2f ((400 -_leftText.GetLocalBounds().Width) / 2f + 400f, 0);
		}

		public void UpdateRight()
		{
			_right++;
			_rightText.DisplayedString = String.Format ("{0}", _right);
			_rightText.Position = new SFML.Window.Vector2f ((400 -_rightText.GetLocalBounds().Width) / 2f, 0);
		}

	}
}

