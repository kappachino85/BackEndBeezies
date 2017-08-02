using BackEndBeezies.Data;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BackEndBeezies.Bot
{
    [LuisModel("01a40676-f81b-4687-9347-04f09e796b08", "d753c0b3671c4577ab5e6ab799569079")]
    [Serializable]
    public class BackendLuisDialog : LuisDialog<object>
    {
        DialogMethods say = new DialogMethods();

        [LuisIntent("Greeting")]
        public async Task SayHi(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"{ say.Hello() }");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Insult")]
        public async Task TakeInsult(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"{ say.Insult() }");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Affirmation")]
        public async Task AffirmativeAction(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"{ say.Affirm() }");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Compliment")]
        public async Task ReceiveCompliment(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"{ say.Gratitude() }");
            context.Wait(MessageReceived);
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"{ say.Unknown() }");
            context.Wait(MessageReceived);          
        }
        
    }
}