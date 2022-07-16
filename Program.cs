using DSharpPlus;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CoreyBot
{
    class Program
    {
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
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = _config["token"],
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.Contains("hello"))
                {
                    await e.Message.RespondAsync("world");
                }
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
