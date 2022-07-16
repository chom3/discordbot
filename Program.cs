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
                Token = "OTk3NjE2MjcwNzQyNjU0OTk2.G0t8tC.GNyAb919wDyEZpmv1kgot-s4ITwO2GnUIbwqGs",
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
