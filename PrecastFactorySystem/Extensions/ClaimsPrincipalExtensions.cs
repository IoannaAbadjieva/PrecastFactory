namespace System.Security.Claims
{
	public static class ClaimsPrincipalExtensions
	{
		public static string Id(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		}

		public static bool IsAdmin(this ClaimsPrincipal user)
		{
			return user.IsInRole("Administrator");
		}

		public static bool IsManager(this ClaimsPrincipal user)
		{
			return user.IsInRole("Manager");
		}

		public static bool IsReinforceManager(this ClaimsPrincipal user)
		{
			return user.IsInRole("ReinforceManager");
		}

		public static bool IsPrecastProductionManager(this ClaimsPrincipal user)
		{
			return user.IsInRole("PrecastProductionManager");
		}

	}
}
