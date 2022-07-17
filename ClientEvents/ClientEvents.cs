using DSharpPlus;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CoreyBot
{
    public class ClientEvents
    {
        private EventId _botId;
        public ClientEvents(EventId botId)
        {
            _botId = botId;
        }

        public Task ClientReady(DiscordClient sender, ReadyEventArgs e)
        {
            sender.Logger.LogInformation(_botId, "Client is ready to process events.");
            return Task.CompletedTask;
        }

        public Task ClientGuildAvailable(DiscordClient sender, GuildCreateEventArgs e)
        {
            sender.Logger.LogInformation(_botId, $"Guild available: {e.Guild.Name}");
            return Task.CompletedTask;
        }

        public Task ClientError(DiscordClient sender, ClientErrorEventArgs e)
        {
            sender.Logger.LogError(_botId, e.Exception, "Exception occured");
            return Task.CompletedTask;
        }
    }
}
