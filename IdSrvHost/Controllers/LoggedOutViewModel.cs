namespace IdSrvHost.Controllers
{
	internal class LoggedOutViewModel
	{
		public bool AutomaticRedirectAfterSignOut { get; set; }
		public object PostLogoutRedirectUri { get; set; }
		public object ClientName { get; set; }
		public object SignOutIframeUrl { get; set; }
		public string LogoutId { get; set; }
	}
}