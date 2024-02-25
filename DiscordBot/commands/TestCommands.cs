using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBot{

    public class TestCommands : BaseCommandModule{

        [Command("test")]
        public async Task MyFirstCommand(CommandContext ctx){
            await ctx.Channel.SendMessageAsync($"Hello! {ctx.User.Username}");
        }

        [Command("google")]
        public async Task SocialCommand(CommandContext ctx){
            await ctx.Channel.SendMessageAsync("find google here: https://www.google.com/");
        }
        
    }



}