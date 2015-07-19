using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Chess.Migrations;
using Chess.Models;

namespace Chess.DataContexts
{
	public class ChessDb : IdentityDbContext<IdentityUser>
	{
		public ChessDb()
			: base("DefaultConnection")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChessDb, Migrations.Configuration>());
		}

		public DbSet<SaveGame> SaveGames;
	}
}