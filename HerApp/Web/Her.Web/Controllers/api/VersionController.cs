using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Her.Services.VersionServcie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Her.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
		private IVersionService _versionService;

		public VersionController(IVersionService vr)
		{
			_versionService = vr;
		}
		[Route("UpdateBuildVersion/{gid}")]
		public IActionResult UpdateBuildVersion(string gid)
		{
			if(gid == "F077BD4A-6C3C-41A8-861E-A92BB3EF3028")
			{
				_versionService.UpdateBuildVersion(Commons.Enums.Domain.VersionTypeEnum.Dev);
			}
			return Ok();
		}
    }
}