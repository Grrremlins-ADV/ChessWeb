using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Chess.DataContexts;

namespace Chess.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private readonly ChessDb db;

		public AccountController()
			: this(new UserManager<IdentityUser>(new UserStore<IdentityUser>(new ChessDb())))
		{
			db = new ChessDb();
			UserManager.UserValidator =
				new UserValidator<IdentityUser>(UserManager)
				{
					AllowOnlyAlphanumericUserNames = false
				};
		}

		public AccountController(UserManager<IdentityUser> userManager)
		{
			UserManager = userManager;
		}

		public UserManager<IdentityUser> UserManager { get; private set; }

		//
		// GET: /Account/Register
		[AllowAnonymous]
		public ActionResult Register(string returnUrl = null)
		{
			throw new NotImplementedException();
			//return View(new RegisterViewModel { ReturnUrl = returnUrl });
		}

		public ActionResult LogOff()
		{
			throw new NotImplementedException();
		}

		public ActionResult Login()
		{
			throw new NotImplementedException();
		}
	}
}
