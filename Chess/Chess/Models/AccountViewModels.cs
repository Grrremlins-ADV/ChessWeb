using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chess.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "{0} — это обязательное поле")]
		[Display(Name = "Имя (логин)")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "{0} — это обязательное поле")]
		[StringLength(100, ErrorMessage = "{0} должен быть длиной как минимум {2} символов.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Подтвердите пароль")]
		// ReSharper disable once CSharpWarnings::CS0618
		[System.Web.Mvc.Compare("Password", ErrorMessage = "Подтверждение пароля и пароль отличаются.")]
		public string ConfirmPassword { get; set; }

		public string ReturnUrl { get; set; }
	}
	public class LoginViewModel
	{
		[Required(ErrorMessage = "{0} — это обязательное поле")]
		[Display(Name = "Имя (логин)")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "{0} — это обязательное поле")]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		[Display(Name = "Запомнить меня")]
		public bool RememberMe { get; set; }
	}
}