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
                GetCardwButton(Strings.TeamNotificationHeaderText, Strings.TeamNotificationContent, appBaseUri + "/content/Notifications.png", "https://gww.blog.gov.bc.ca/unifiedcommunications/", "String"),
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
                GetCardwButton(Strings.O365HelpTitle, Strings.O365HelpBody, appBaseUri + "/content/BeachBot.png","https://bcgov.sharepoint.com/", "Info Centre"),
                GetCardwButton(Strings.UCBlogTitle, Strings.UCBlogBody, appBaseUri + "/content/BotPNGBlog.png", "https://gww.blog.gov.bc.ca/unifiedcommunications/", "UC Site"),
                GetCardwButton(Strings.ContactUsTitle, Strings.ContactUsBody, appBaseUri + "/content/BotPNGContactUs.png", "https://bcgov.sharepoint.com/teams/Office365Portal/SitePages/Support.aspx", "Contact Us"),
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
        private static Attachment GetCardwButton(string title, string text, string imageUri, string redirectUrl, string buttonTitle)
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
                  DisplayText = buttonTitle,
                  Text = buttonTitle,
                  Title = buttonTitle,
                  Value = redirectUrl,
                },
              },
            };

            return helpCarouselCard.ToAttachment();
        }
    }
}
