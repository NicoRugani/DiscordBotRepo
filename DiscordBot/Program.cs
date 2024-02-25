using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.config;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace DiscordBot{

    internal class Program{

        private static DiscordClient Client {get; set;}
        private static CommandsNextExtension Commands{get; set;}

        static async Task Main(string[] args){
            var jsonreader = new JSONReader();
            await jsonreader.ReadJSON();

            var discordConfig = new DiscordConfiguration(){
                Intents = DiscordIntents.All,
                Token = jsonreader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true

            };

            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;

            var commandsConfig = new CommandsNextConfiguration(){
                
                StringPrefixes = new string[] {jsonreader.prefix},
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false, 

            };

            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<TestCommands>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args){
            return Task.CompletedTask;
        }
    }
    
}
