// <copyright file="UnrecognizedInputCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.FAQPlusPlus.Cards
{
    using System.Collections.Generic;
    using AdaptiveCards;
    using Microsoft.Bot.Schema;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Models;
    using Microsoft.Teams.Apps.FAQPlusPlus.Properties;

    /// <summary>
    ///  This class handles unrecognized input sent by the user-asking random question to bot.
    /// </summary>
    public static class UnrecognizedInputCard
    {
        /// <summary>
        /// This method will construct the card when unrecognized input is sent by the user.
        /// </summary>
        /// <param name="userQuestion">Actual question asked by the user to the bot.</param>
        /// <returns>UnrecognizedInput Card.</returns>
        public static Attachment GetCard(string userQuestion)
        {
            AdaptiveCard unrecognizedInputCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 0))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = Strings.CustomMessage,
                        Wrap = true,
                    },
                },
                
                Actions = new List<AdaptiveAction>
                {
                // Adds the "Share Feedback" Button  
                    new AdaptiveSubmitAction
                    {
                        Title = Strings.ShareFeedbackButtonText,
                        Data = new ResponseCardPayload
                        {
                            MsTeams = new CardAction
                            {
                                Type = ActionTypes.MessageBack,
                                DisplayText = Strings.ShareFeedbackDisplayText,
                                Text = Constants.ShareFeedback,
                            },
                            UserQuestion = userQuestion,
                            KnowledgeBaseAnswer = answer,
                        },
                    },
                };
                
                // Adds the "My Service Centre" button.
                    new AdaptiveOpenUrlAction
                    {
                        Title = Strings.MyServiceCentreButtonText,
                        Url = new System.Uri("https://ociomysc.service-now.com/sp?id=ocio_sr_itsm_landing"),  
                    },
                };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = unrecognizedInputCard,
            };
        }
    }
}
