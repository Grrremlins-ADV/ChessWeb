using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using NUnit.Framework;
using SrcChess2;
using SrcChess2.Properties;

namespace Chess
{
	[TestFixture]
	public class ChessEngineTests
	{

		[Test]
		public void BoardCreation()
		{
			var board = new ChessBoard();
			var piece = board[0];
			Console.WriteLine(piece.ToString());
		}

		[Test]
		public void Turn()
		{
			var board = new ChessBoard();
			var piece = board[17];
			Console.WriteLine(piece.ToString());
			board.DoMove(new ChessBoard.MovePosS()
			{
				EndPos = 17,
				StartPos = 9
			});
			piece = board[17];
			Console.WriteLine(piece.ToString());
		}

		[Test]
		public void TurnColor()
		{
			var board = new ChessBoard();
			Console.WriteLine(board.CurrentMoveColor);
			board.DoMove(new ChessBoard.MovePosS()
			{
				EndPos = 17,
				StartPos = 9
			});
			Console.WriteLine(board.CurrentMoveColor);
		}

		[Test]
		public void SearchEngine()
		{
			var board = new ChessBoard();

			ChessBoard.MovePosS bestMove;
			int iPremCount;
			int iCacheHit;
			int iMaxDepth;

			board.FindBestMove(
				new SearchEngine.SearchMode(
					new BoardEvaluationUtil().BoardEvaluators[0],
					new BoardEvaluationUtil().BoardEvaluators[0],
					SrcChess2.SearchEngine.SearchMode.OptionE.UseAlphaBeta,
					SrcChess2.SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch,
					2,
					15,
					SrcChess2.SearchEngine.SearchMode.RandomModeE.Off
					),
				ChessBoard.PlayerColorE.Black,
				out bestMove,
				out iPremCount,
				out iCacheHit,
				out iMaxDepth);
			Console.WriteLine(bestMove.StartPos + @"   " + bestMove.EndPos);
		}
	}
}