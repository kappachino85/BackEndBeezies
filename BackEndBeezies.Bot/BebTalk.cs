using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using BackEndBeezies.Data;

namespace BackEndBeezies.Bot
{
    [Serializable]
    public class BebTalk : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ActivityReveivedAsync);
        }

        private async Task ActivityReveivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            Activity activity = await result as Activity;
            if (activity.Text.Contains("how many members are in the backend bitches"))
            {
                BackEndBitches bitches = new BackEndBitches();
                await context.PostAsync($"There are { bitches.CountBitches() } bitches.");
            }
            //if (activity.Text.Contains("list the guys"))
            //{
            //    BackEndBitches bitches = new BackEndBitches();
            //    await context.PostAsync($"The male bitches are { bitches.GetMaleBitches() }.");
            //}
            //if (activity.Text.Contains("list the girls"))
            //{
            //    BackEndBitches bitches = new BackEndBitches();
            //    await context.PostAsync($"There are { bitches.GetFemaleBitches() } members.");
            //}
            //if (activity.Text.Contains("who are the backend bitches"))
            //{
            //    BackEndBitches bitches = new BackEndBitches();
            //    await context.PostAsync($"They are { bitches.GetBitches() }.");
            //}
            if (activity.Text.Contains("are you a member of the backend bitches"))
            {
                await context.PostAsync("No. I am only an assistant bitch, currently in development.");
            }
            if (activity.Text.Contains("hi") || activity.Text.Contains("hello"))
            {
                await context.PostAsync("Hello.");
            }
            if (activity.Text.Contains("who are the backend bitches"))
            {
                await context.PostAsync("They are Jeremy, MyLinh, Sonny, Alexa, Andres, Adan, Tiana, and you.");
            }
            if (activity.Text.Contains("who am i"))
            {
                await context.PostAsync("Jae");
            }
            if (activity.Text.Contains("say it the other way"))
            {
                await context.PostAsync("Waddup, SON!");
            }
            context.Wait(ActivityReveivedAsync);
        }
    }
}