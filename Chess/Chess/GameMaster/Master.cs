using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using SrcChess2;

namespace Chess.GameMaster
{
	public class Master
	{
		private readonly Dictionary<Players, Game> gameStorage;
		private readonly HashSet<string> users;

		public Master()
		{
			users = new HashSet<string>();
			gameStorage = new Dictionary<Players, Game>();
			var gameStorageClearDemon = new GameStorageCleaner(gameStorage);
			try
			{
				gameStorageClearDemon.Start();
			}
			catch (Exception)
			{
				gameStorageClearDemon.Dispose();
			}
		}

		public Game FindGame(string userName)
		{
			return null;
		}

		public void StartNewGameWithBot(string userName)
		{
			var game = new Game();
			gameStorage.Add(new Players(userName, null), game);
		}

		public Game GetCurrentGame(string userName)
		{
			if (!gameStorage.Keys.Any(p => p.HasPlayer(userName)))
				throw new Exception(String.Format("User {0} is not play now", userName));
			return gameStorage.First(x => x.Key.HasPlayer(userName)).Value;
		}
	}
}