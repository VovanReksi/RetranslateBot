using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using RetranslateBot.Temp;

namespace RetranslateBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity == null) return;
            
            var reTranslateString = ReTranslateManager.Instance.ReTranslate(activity.Text);
            
            await context.PostAsync(reTranslateString);

            context.Wait(MessageReceivedAsync);
        }
    }
}