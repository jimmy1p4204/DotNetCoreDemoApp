using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemoApp.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class DemoController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<DemoController> _logger;

		public DemoController(ILogger<DemoController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<Demo> Index()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new Demo
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}

		[HttpGet]
		public string Demo1()
		{
			return "Hello World 1";
		}
		
		[HttpGet]
		public string Demo2()
		{
			return "Hello World 2";
		}

		[HttpGet]
		public IEnumerable<Demo> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new Demo
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
