using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Chess.Models;

namespace Chess.DataContexts
{
	public class SaveGameRepo
	{
		private readonly ChessDb db;

		public SaveGameRepo()
			: this(new ChessDb())
		{

		}

		public SaveGameRepo(ChessDb db)
		{
			this.db = db;
		}

		public SaveGame GetNotFinishedGame(string userName)
		{
			return db.SaveGames.First(g => g.User1 == userName && g.User2 == "Gremlin" && !g.End);
		}

		public SaveGame GetNotFinishedGame(string userName1, string userName2)
		{
			return db.SaveGames.First(g => g.User1 == userName1 && g.User2 == userName2 && !g.End);
		}

		public async Task AddGame(string userName, int[] field, string winnerName)
		{
			var lastGameWithBot = db.SaveGames.FirstOrDefault(g => g.User1 == userName && g.User2 == "Gremlin" && !g.End);
			if (lastGameWithBot != null)
				db.SaveGames.Remove(lastGameWithBot);
			await db.SaveChangesAsync();
			await AddGame(userName, "Gremlin", field, winnerName);
		}

		public async Task AddGame(string userName1, string userName2, int[] field, string winnerName)
		{
			db.SaveGames.Add(new SaveGame
			{
				User1 = userName1,
				User2 = userName2,
				Field = field,
				End = winnerName != null,
				WinnerName = winnerName
			});
			await db.SaveChangesAsync();
		}
	}
}