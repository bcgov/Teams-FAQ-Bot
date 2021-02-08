// <copyright file="TourCarousel.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
namespace Microsoft.Teams.Apps.FAQPlusPlus.Cards
{
    using System.Collections.Generic;
    using Microsoft.Bot.Schema;
    using Microsoft.Teams.Apps.FAQPlusPlus.Properties;

    /// <summary>
    ///  This class process Help Carousel feature : A custom feature for the OCIO Bot
    /// </summary>
    public static class TeamsHelpCard
    {
        /// <summary>
        /// Create the set of cards that comprise the teams help carousel.
        /// </summary>
        /// <param name="appBaseUri">The base URI where the app is hosted.</param>
        /// <returns>The cards that comprise the help carousel.</returns>
        public static IEnumerable<Attachment> GetTeamHelpCards(string appBaseUri)
        {
            return new List<Attachment>()
            {
                GetCardwButton(Strings.TeamNotificationHeaderText, Strings.TeamNotificationContent, appBaseUri + "/content/Notifications.png", "https://gww.blog.gov.bc.ca/unifiedcommunications/"),
                //GetCard(Strings.TeamChatHeaderText, Strings.TeamChatContent, appBaseUri + "/content/Enduserchat.png"),
                //GetCard(Strings.TeamTicketSystemHeaderText, Strings.TeamTicketSystemContent, appBaseUri + "/content/Ticketsystem.png"),
            };
        }

        /// <summary>
        /// Create the set of cards that comprise the user tour carousel.
        /// </summary>
        /// <param name="appBaseUri">The base URI where the app is hosted.</param>
        /// <returns>The cards that comprise the user tour.</returns>
        public static IEnumerable<Attachment> GetUserHelpCards(string appBaseUri)
        {
            return new List<Attachment>()
            {
                GetCardwButton("UC Blog Help Site", "This site has everything anyone could need to know about UC. If your question is regarding Skype, Skype Online Meetings, Headphones, or Deskphones this is where your answer likely is.", appBaseUri + "/content/Askaquestion.png","https://gww.blog.gov.bc.ca/unifiedcommunications/"),
                GetCardwButton("Teams Sharepoint Help Site", "This site has all things Teams related including links to training sessions and FAQs. If your question is Teams related, this is where your answer likely is.", appBaseUri + "/content/Expertinquiry.png", "https://bcgov.sharepoint.com/teams/Office365Portal"),
                GetCardwButton("Contact Us", "If there is a problem and you require a technician, you can contact the help desk.", appBaseUri + "/content/Sharefeedback.png", "https://bcgov.sharepoint.com/teams/Office365Portal/SitePages/Support.aspx"),
            };
        }

        private static Attachment GetCard(string title, string text, string imageUri)
        {
            HeroCard helpCarouselCard = new HeroCard()
            {
                Title = title,
                Text = text,
                Images = new List<CardImage>()
                {
                    new CardImage(imageUri),
                },
            };

            return helpCarouselCard.ToAttachment();
        }

        // The Custom Carsol Card Constructor to include the button
        private static Attachment GetCardwButton(string title, string text, string imageUri, string redirectUrl)
        {
            HeroCard helpCarouselCard = new HeroCard(){
              Title = title,
              Text = text,
              Images = new List<CardImage>()
              {
                new CardImage(imageUri),
              },
              Buttons = new List<CardAction>(){
                new CardAction(){
                  Type = ActionTypes.OpenUrl,
                  DisplayText = "Redirect",
                  Value = redirectUrl,
                },
              },
            };

            return helpCarouselCard.ToAttachment();
        }
    }
}
