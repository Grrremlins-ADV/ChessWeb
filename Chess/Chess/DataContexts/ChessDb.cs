using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Chess.Migrations;

namespace Chess.DataContexts
{
	public class ChessDb : IdentityDbContext<IdentityUser>
	{
		public ChessDb()
			: base("DefaultConnection")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChessDb, Migrations.Configuration>());
		}
	}
}