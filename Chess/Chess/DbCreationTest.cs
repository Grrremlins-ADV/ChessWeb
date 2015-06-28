using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Chess.DataContexts;
using NUnit.Framework;

namespace Chess
{
	public class ExecutionServiceMigration_Test
	{
		[Explicit]
		[Test]
		public void TestSources()
		{
			AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetFullPath(@"..\App_Data\"));
			var db = new ChessDb();
			Console.WriteLine(db.Users.Count());
		}
	}
}