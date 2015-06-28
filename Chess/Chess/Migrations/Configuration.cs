using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Chess.DataContexts;

namespace Chess.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<ChessDb>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		public class LmsRoles
		{
			public const string Admin = "admin";
			public const string User = "user";
		}
		protected override void Seed(ChessDb context)
		{
			var roleStore = new RoleStore<IdentityRole>(context);
			var roleManager = new RoleManager<IdentityRole>(roleStore);
			roleManager.Create(new IdentityRole(LmsRoles.User));
			roleManager.Create(new IdentityRole(LmsRoles.Admin));
			if (!context.Users.Any(u => u.UserName == "user"))
			{
				var userStore = new UserStore<IdentityUser>();
				var manager = new UserManager<IdentityUser>(userStore);
				var user = new IdentityUser { UserName = "user" };
				manager.Create(user, "asdasd");
			}
			if (!context.Users.Any(u => u.UserName == "admin"))
			{
				var userStore = new UserStore<IdentityUser>();
				var manager = new UserManager<IdentityUser>(userStore);
				var user = new IdentityUser { UserName = "admin" };
				manager.Create(user, "fullcontrol");
				manager.AddToRoleAsync(user.Id, LmsRoles.Admin);
			}
			context.SaveChanges();
		}
	}
}