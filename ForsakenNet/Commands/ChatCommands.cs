using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForsakenNet.Commands
{
    public class ChatCommands : ModuleBase<SocketCommandContext>
    {
		Tasks.HTTPClientTask clientTask = new Tasks.HTTPClientTask();

		[Command("test")]
		[Summary("testing new intern shit")]
		public async Task Test(string search = "alhalla")
		{
			string info = await clientTask.getClient("https://www.game.co.uk/en/games/assassins-creed/valhalla?cm_sp=deals-_-espot1-_-ACValhalla");
			//await Logging.Log.WriteLog(info, Logging.LogType.Log);
			await ReplyAsync(info.Contains(search) ? "Yes" : "No");
			//await Task.CompletedTask;
		}

		[Command("uptime")]
		[Summary("Bot Uptime")]
		public async Task uptime()
		{
			var timeSpan = TimeSpan.FromMilliseconds(Environment.TickCount64);
			EmbedBuilder builder = new EmbedBuilder();
			builder.WithTitle($"Time Running");
			builder.WithCurrentTimestamp();
			builder.WithThumbnailUrl("https://media.giphy.com/media/psIw9yvUL8rR3AsJwj/giphy.gif");
			builder.AddField($"Server Uptime:", $"{timeSpan:%d\\:hh\\:mm\\:ss}");
			builder.AddField($"Bot Uptime:", $"{Program.Uptime.getTime()}");
			builder.WithFooter($"ForsakenBot V0.0.1");
			await ReplyAsync($"", false, builder.Build());
		}



	}
}
