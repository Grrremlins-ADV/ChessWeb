using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using Chess.DataContexts;
using Chess.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

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
			return View(new RegisterViewModel { ReturnUrl = returnUrl });
		}

		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new IdentityUser() { UserName = model.UserName };
				var result = await UserManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					await SignInAsync(user, isPersistent: false);
					if (string.IsNullOrWhiteSpace(model.ReturnUrl))
						return RedirectToAction("Index", "Home");
					return RedirectToLocal(model.ReturnUrl);
				}
				AddErrors(result);
			}
			return View(model);
		}

		private ActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		private IAuthenticationManager AuthenticationManager
		{
			get { return HttpContext.GetOwinContext().Authentication; }
		}

		private async Task SignInAsync(IdentityUser user, bool isPersistent)
		{
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
			var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
			AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
			//System.Web.Security.FormsAuthentication.SetAuthCookie(user.UserName, false);
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error);
			}
		}

		//
		// POST: /Account/LogOff
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff()
		{
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

			return RedirectToAction("Index", "Home");
		}

		//
		// GET: /Account/Login
		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		//
		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				var user = await UserManager.FindAsync(model.UserName, model.Password);
				if (user != null)
				{
					await SignInAsync(user, model.RememberMe);
					return RedirectToLocal(returnUrl);
				}
				else
				{
					ModelState.AddModelError("", "Неверное имя пользователя или пароль.");
				}
			}
			return View(model);
		}
	}
}
