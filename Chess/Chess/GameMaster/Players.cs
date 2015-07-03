using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.GameMaster
{
	public class Players
	{
		public string Player1 { get; private set; }
		public string Player2 { get; private set; }
		public DateTime LastStepTime { get; set; }

		/// <summary>
		/// if parametr == null => it's a bot
		/// </summary>
		public Players(string player1, string player2)
		{
			Player1 = player1;
			Player2 = player2;
			LastStepTime = DateTime.Now;
		}

		public bool HasPlayer(string userName)
		{
			return Player1 == userName || Player2 == userName;
		}
	}
}