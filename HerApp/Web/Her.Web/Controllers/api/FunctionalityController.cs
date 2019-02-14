using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Her.Context;
using Her.Domain.Entities;
using Her.Domain.Entities.Dictionaries;
using Her.Domain.Entities.Wro;
using Her.Services.AzureServices;
using Her.Services.EmailService;
using Her.Services.Extensions;
using Her.Services.FunctionalityService;
using Her.Services.TaskService;
using Her.Services.UserService;
using Her.Services.WrocService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Her.Web.Controllers.api
{
	[Produces("application/json")]
	[Route("api/Functionality")]
	public class FunctionalityController : Controller
	{
		private IFunctionalityService _functionalityService;
		private IQueueServcie _queue;
		private readonly IHttpClientFactory _httpClientFactory;
		private IConfiguration configuration;
		private IWrocService _wrocService;
		private IUserService _userService;
		private IEmailService _emailService;
		public FunctionalityController(IEmailService emailService,IUserService userService, IWrocService wrocService, IFunctionalityService functionalityService, IQueueServcie queue, IHttpClientFactory httpClientFactory, IConfiguration asd)
		{
			_userService = userService;
			_functionalityService = functionalityService;
			_queue = queue;
			_httpClientFactory = httpClientFactory;
			configuration = asd;
			_wrocService = wrocService;
			_emailService = emailService;
		}

		[HttpPost]
		[Route("SendReminderTask")]
		public IActionResult SendReminderTask()
		{
			var daily = _functionalityService.GetReminderTask();
			
			_emailService.SendTaskReminderAsync(daily);
			return Ok();
		}

		[HttpPost]
		[Route("SendDailyMail")]
		public IActionResult SendDailyMail()
		{
			//var dailyMail = _functionalityService.GetDailyMail();
			//_emailService.SendTaskReminderAsync(dailyMail);
			//_queue.AddMailsToMailNotification();
			return Ok();
		}

		[HttpPost]
		[Route("PrepareDailyEvents")]
		public async Task<IActionResult> PrepareDailyEventsAsync()
		{
			if (DateTime.Now.Hour != 1 || DateTime.Now.Minute < 15)
			{
				return Ok(new
				{
					message = "WrongTime",
				});
			}
			bool isReady = false;
			var time = DateTimeOffset.UtcNow.AddDays(-1).ToUnixTimeMilliseconds();
			var uri = configuration.GetSection("WroCredential")["EventsUrl"] + "&time-from=" + time + "&time-to=" + DateTimeOffset.UtcNow.AddDays(3).ToUnixTimeMilliseconds();

			var client = _httpClientFactory.CreateClient();
			while (!isReady)
			{

				isReady = true;
				var service = _wrocService.SaveDailyEventsAsync(await client.GetStringAsync(uri));
				if (!string.IsNullOrEmpty(service))
				{
					isReady = false;
					uri = service;
				}
			}
			return Ok();
		}

		[HttpPost]
		[Route("PrepareDailyWroEventForUser")]
		public IActionResult PrepareDailyWroEventForUser()
		{
			var events = _userService.PrepareDailyWroEventForUsers();
			return Ok();
		}
	}
}