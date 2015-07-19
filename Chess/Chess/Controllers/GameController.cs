using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Chess.DataContexts;
using Chess.GameMaster;
using Chess.Models;
using SrcChess2;
using SrcChess2.Properties;

namespace Chess.Controllers
{
	public class GameController : Controller
	{
		private readonly ChessMaster chessMaster;
		private readonly SaveGameRepo gameRepo = new SaveGameRepo();
		public GameController()
		{
			chessMaster = new ChessMaster();
		}

		public ActionResult ChessField()
		{
			var opponentName = GetBotName();
			return View(new ChessFieldModel { OpponentName = opponentName });
		}

		private static string GetBotName()
		{
			var random = new Random().Next()%3;
			var opponentName = random == 0
				? "Гремлин младший"
				: random == 1
					? "Гремлин средний"
					: "Гремлин старший";
			return opponentName;
		}

		[HttpPost]
		[Authorize]
		public string SendField(string field)
		{
			return field;
		}

		[Authorize]
		public ActionResult StartGameWithBot()
		{
			chessMaster.StartNewGameWithBot(User.Identity.Name);
			return View(new ChessFieldModel { OpponentName = GetBotName() });
		}

		[Authorize]
		public ActionResult StartGameWithPlayer()
		{
			chessMaster.FindGame(User.Identity.Name);
			return View(new ChessFieldModel { OpponentName = GetBotName() });
		}

		[Authorize]
		public ActionResult MakeUserStep(int[] field, string opponentName, int step)//еще параметры, чтобы понять как именно сходил чувак, пусть пока это будет int
		{
			var userName = User.Identity.Name;
			var lastSavedGame = gameRepo.GetNotFinishedGame(userName, opponentName);
			if (!CompareFields(field, lastSavedGame.Field) || !IsCorrectOpponentName(opponentName, lastSavedGame))
				return View("ChessField", new object());//какая-то модель, которая скажет что чо-то ты не ту доску мне подсунул, негодяй ушастый
			var game = chessMaster.GetCurrentGame(userName);
			game.MakeStep(step);
			return View("ChessField", new ChessFieldModel { OpponentName = opponentName});
		}

		private static bool IsCorrectOpponentName(string opponentName, SaveGame lastSavedGame)
		{
			return opponentName == lastSavedGame.User1 || opponentName == lastSavedGame.User2;
		}

		private bool CompareFields(int[] field, int[] ints)
		{
			return false;
		}
	}
}
