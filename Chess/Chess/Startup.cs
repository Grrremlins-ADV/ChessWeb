using System.IO;
using System.Text;
using System.Web.Hosting;
using Microsoft.Owin;
using Owin;
using Chess;

[assembly: OwinStartup(typeof(Startup))]

namespace Chess
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}