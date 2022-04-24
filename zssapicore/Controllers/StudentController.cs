using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace zssapicore.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private IWebHostEnvironment _server;
		public StudentController(IWebHostEnvironment server)
		{
			_server = server;
		}

		public async Task<string> Post()
		{
			IFormCollection form = await Request.ReadFormAsync();
			IFormFile file = form.Files[0];

			using (var stream = System.IO.File.Create(Path.Combine(_server.WebRootPath, file.FileName)))
			{
				file.CopyTo(stream);
			}

			return Path.Combine("/", file.FileName);
		}

		[Route("{id}")]
		public string Get(int id)
		{
			return "hello:" + id;
		}
	}
}
