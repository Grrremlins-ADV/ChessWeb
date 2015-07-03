using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Chess.GameMaster;
using Chess.Models;
using SrcChess2;
using SrcChess2.Properties;

namespace Chess.Controllers
{
	public class GameController : Controller
	{
		private readonly Master gameMaster;

		public GameController()
		{
			gameMaster = new Master();
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
			gameMaster.StartNewGameWithBot(User.Identity.Name);
			return View(new ChessFieldModel { OpponentName = GetBotName() });
		}

		[Authorize]
		public ActionResult StartGameWithPlayer()
		{
			gameMaster.FindGame(User.Identity.Name);
			return View(new ChessFieldModel { OpponentName = GetBotName() });
		}
	}
}
