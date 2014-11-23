/*
 * Created by SharpDevelop.
 * User: Regis
 * Date: 22/11/2014
 * Time: 18:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace OneHourPong
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Game g = new Game();
			g.Run();
		}	
		
	}
}
