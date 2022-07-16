using DSharpPlus;
using System;
using System.Threading.Tasks;

namespace DBHelloWorld
{


    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = "",
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
