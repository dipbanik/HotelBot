using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace HotelBot.Dialogs
{
    [Serializable]
    public class GreetingDialogs : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hi, I'm Dip Bot.");
            await Respond(context);
            context.Wait(MessageRecievedAsync);

        }

        public async Task MessageRecievedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            var userName = String.Empty;
            var getName = false;

            context.UserData.TryGetValue<string>("Name", out userName);
            context.UserData.TryGetValue<bool>("GetName", out getName);

            if (getName)
            {
                userName = message.Text;
                context.UserData.SetValue<string>("Name", userName);
                context.UserData.SetValue<bool>("GetName", false);
            }

            await Respond(context);
            context.Done(message);
        }

        public static async Task Respond(IDialogContext context)
        {
            var userName = String.Empty;
            context.UserData.TryGetValue<string>("Name", out userName);
            if (string.IsNullOrEmpty(userName))
            {
                await context.PostAsync("What is your name?");
                context.UserData.SetValue<bool>("GetName", true);
            }
            else
            {
                await context.PostAsync(String.Format("Hi {0}, How can I help you today?", userName));
            }
        }

        //public virtual async Task MessageRecievedAsync(IDialogContext context, IAwaitable<IMessageActivity> arguement)
        //{
        //    var message = await arguement;
        //    var userName = String.Empty;
        //    var getName = false;
            
        //    context.UserData.TryGetValue<string>("Name", out userName);
        //    context.UserData.TryGetValue<bool>("GetName", out getName);

        //    if(getName)
        //    {
        //        userName = message.Text;
        //        context.UserData.SetValue<string>("Name", userName);
        //        context.UserData.SetValue<bool>("GetName", false);
        //    }

        //    if (string.IsNullOrEmpty(userName))
        //    {
        //        await context.PostAsync("What is your name?");
        //        context.UserData.SetValue<bool>("GetName", true);
        //    }
        //    else
        //    {
        //        await context.PostAsync(String.Format("Hi {0}, How can I help you today?", userName));
        //    }
        //    context.Wait(MessageRecievedAsync);
        //}
    }
}