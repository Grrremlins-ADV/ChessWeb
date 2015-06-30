using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chess.Models;
using SrcChess2;

using SrcChess2.Properties;

namespace Chess.Controllers
{
	public class GameController : Controller
	{

		public ActionResult ChessField()
		{
			var opponentName = "";
			var random = new Random().Next() % 3;
			opponentName = random == 0 ? "Гремлин младший" :
				random == 1 ? "Гремлин средний" :
			"Гремлин старший";
			return View(new ChessFieldModel { OpponentName = opponentName });
		}
	}
}
