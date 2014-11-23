using System;
using SFML.Graphics;
using SFML.Window;

namespace OneHourPong
{
	public class StartScene
	{
		private Text _name;
		private Text _copyright;
		private Text _message;
		private Text _help;

		public StartScene ()
		{
			Font font = new Font ("Data/Square.ttf");

			_name = new Text ("PONG", font, 100);
			_name.Position = new Vector2f ((800 - _name.GetLocalBounds ().Width) / 2f, 100);

			_copyright = new Text ("(c) Régis FLORET 2014", font, 50);
			_copyright.Position = new Vector2f ((800 - _copyright.GetLocalBounds ().Width) / 2f, 250);

			_message = new Text ("Press any key to start", font, 50);
			_message.Position = new Vector2f ((800 - _message.GetLocalBounds ().Width) / 2f, 400);

			_help = new Text ("Keys: A and B for left player, Up and Down for right player", font, 20);
			_help.Position = new Vector2f ((800 - _help.GetLocalBounds ().Width) / 2f, 550);
		}

		public void Draw(RenderWindow w)
		{
			w.Draw (_name);
			w.Draw (_copyright);
			w.Draw (_message);
			w.Draw (_help);
		}
	}
}

