using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalR_Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignalRTestController : ControllerBase
	{
		private readonly IHubContext<SignalRHub> _hubContext;
		public SignalRTestController(IHubContext<SignalRHub> hubClients)
		{
			_hubContext = hubClients;
		}
		[HttpGet("index")]
		public string index()
		{
			return "HELLO World";
		}
		[HttpGet("sendall")]
		public void SendAll()
		{
			//给所有人推送消息
			_hubContext.Clients.All.SendAsync("toall", "后端","你好","给所有人发");
		}
		[HttpGet("sendToUser")]
		public void SendToUser(string user)
		{
			//给指定人推送消息
			_hubContext.Clients.Client(user).SendAsync("toall", "后端", $"你好{user}", "只给你发");
		}
	}
}
