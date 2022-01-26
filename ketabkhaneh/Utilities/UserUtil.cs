using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
	public static class UserUtil
	{
		public static string GetUserID(this ClaimsPrincipal claimsPrincipal)
		{
			return Convert.ToString(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
		}
		public static string GetUserName(this ClaimsPrincipal claimsPrincipal)
		{
			return claimsPrincipal.FindFirst(System.Security.Claims.ClaimTypes.Name).ToString().Split(':')[2].ToString();
		}
	}
}
