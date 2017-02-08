using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;



namespace EunjiBot.Dialogs
{
    [Serializable]
    //[LuisModel("162bf6ee-379b-4ce4-a519-5f5af90086b5", "11be6373fca44ded80fbe2afa8597c18")]
    //[LuisModel("YourModelId", "YourSubscriptionKey")]
    [LuisModel("ea02316e-ce41-4d4f-819d-9292bba91361", "8ca5b18a3b5f46f1a039033f4b88a643")]
    public class RootLuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Please try with another sentence. Example - How much mileage do I have?");
            context.Wait(this.MessageReceived);
        }

        
        [LuisIntent("CheckMileage")]
        public async Task Price(IDialogContext context, LuisResult result)
        {
            string response = null;

            //result 에 담긴 Luis 데이터를 받아와서 그 중 Intent 값과, Entities 값 출력
            string intent0 = result.Intents[0].Intent;
            string entity0 = result.Entities[0].Entity;

            string myresult = "Your intent is"+"  "+intent0 + " / ";
            string myresult1 = "Your entity is" + "  " + entity0;

            if (intent0 == "CheckMileage")
            {
                response = myresult + myresult1;
                await context.PostAsync(response);
                context.Wait(this.MessageReceived);
            }

            
        }

    }
}