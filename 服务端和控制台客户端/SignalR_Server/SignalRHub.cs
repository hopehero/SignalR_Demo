using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalR_Server
{
	public class SignalRHub:Hub
	{
		public  async Task sendall(string user, string message)
		{
			await Clients.All.SendAsync("toall",user,message,"给所有人发");
			
		}
		/// <summary>
		/// 重写集线器连接事件
		/// </summary>
		/// <returns></returns>
		public override Task OnConnectedAsync()
		{
			Console.WriteLine($"{Context.ConnectionId}已连接");
			return base.OnConnectedAsync();
		}
		/// <summary>
		/// 重写集线器关闭事件
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		public override Task OnDisconnectedAsync(Exception exception)
		{
			Console.WriteLine("触发了关闭事件");
			return base.OnDisconnectedAsync(exception);
		}
	}
}
