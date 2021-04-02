using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ForsakenNet.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ForsakenNet.Events
{
    public class EventHandler
    {
        //Only need to Read the data no need to write info Moron
        private readonly DiscordSocketClient _Client;
        private readonly CommandService _Commands;

        public EventHandler(IServiceProvider service)
        {
            //Declare the Services here..
            _Client = service.GetRequiredService<DiscordSocketClient>();
            _Commands = service.GetRequiredService<CommandService>();
            //Events 
            _Client.Ready += ClientReady;
            _Client.UserJoined += UserJoined;
            _Client.UserLeft += UserLeft;
            _Commands.Log += Commands;
            _Client.JoinedGuild += Test;


        }

        private Task Test(SocketGuild guild)
        {
            Log.WriteLog(guild.ToString(), LogType.Log);
            return Task.CompletedTask;

        }

        private Task Commands(LogMessage log)
        {
            Log.WriteLog($"{log.Message}", LogType.Command);
            return Task.CompletedTask;
        }

        private Task UserLeft(SocketGuildUser arg)
        {
            Log.WriteLog($"User: {arg.Nickname} left the Guild.", LogType.Log);
            return Task.CompletedTask;
        }

        private Task UserJoined(SocketGuildUser arg)
        {
            Log.WriteLog($"User: {arg.Nickname} Joined the guild.", LogType.Log);
            return Task.CompletedTask;
        }

        private Task ClientReady()
        {
            Log.WriteLog($"Client Ready with: {_Client.Latency}MS.", LogType.Log);
            return Task.CompletedTask;
        }
    }
}
