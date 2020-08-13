using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalR_Client
{
	class Program
	{
        static HubConnection connection;

        static void Main(string[] args)
		{

			connection = new HubConnectionBuilder()
			   .WithUrl("http://localhost:5000/ChatHub")
			   .Build();
            
            test();
            Console.Read();
		}
        private static async void test()
        {
            //注册各种事件
            connection.On<string, string,string>("toall", (user, message,aa) =>
            {

                var newMessage = $"{user}: {message}";
                Console.WriteLine(newMessage);
            });

            try
            {
                //等待连接成功
                await connection.StartAsync();

            }
            catch (Exception ex)
            {

            }
        }
    }
	
}
