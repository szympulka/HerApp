using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Her.Services.Extensions
{
	public class UserResolverService
	{
		private readonly IHttpContextAccessor _context;
		public UserResolverService(IHttpContextAccessor context)
		{
			_context = context;
		}

		public string GetUserName()
		{
			var asd = _context.HttpContext;
			return _context.HttpContext.User?.Identity?.Name;
		}

		public ConnectionInfo ConnectionInfo()
		{
			return _context.HttpContext.Connection;
		}

		public ClaimsPrincipal GetUser()
		{
			return _context.HttpContext.User;
		}
	}
}
