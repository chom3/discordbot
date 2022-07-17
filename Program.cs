using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CoreyBot
{
    class Program
    {
        public readonly EventId _botId = new EventId();
        private readonly IConfiguration _config;
        public Program() 
        {
            // create the configuration
            var _builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(path: "appsettings.json");

            // build the configuration and assign to _config          
            _config = _builder.Build();
        }
        static Task Main() => new Program().MainAsync();
        
        public async Task MainAsync()
        {
            using (var services = ConfigureServices())
            {
                var client = services.GetRequiredService<DiscordClient>();
                var clientEvents = new ClientEvents(_botId);

                client.Ready += clientEvents.ClientReady;
                client.GuildAvailable += clientEvents.ClientGuildAvailable;
                client.ClientErrored += clientEvents.ClientError;


                await client.ConnectAsync();
                await Task.Delay(-1);
            }
        }

        private ServiceProvider ConfigureServices()
        {
            var discordClient = new DiscordClient(new DiscordConfiguration()
            {
                Token = _config["token"],
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });
            return new ServiceCollection()
                .AddSingleton(discordClient)
                .BuildServiceProvider();
        }
    }
}
