namespace NewsAPI.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsAPI.Models.NewsAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewsAPI.Models.NewsAPIContext context)
        {
            context.News.AddOrUpdate(x => x.ID,
                new News() {  Title = "Pawel is joining Connect Group", Content = "New Developer is joining our company!", Date = DateTime.Parse("2018-03-26") },
                new News() {  Title = "Connect Group Received an Awared", Content = "Connect has won the Creative Communications & Digital Business of the Year Award at the 2017 Birmingham Post Awards.", Date = DateTime.Parse("15/06/2008 08:30") },
                new News() {  Title = "We're all ears. Podcasts are thriving in the age of screen exhaustion.", Content = "We have two ears and one mouth, so we should listen more than we say.", Date = DateTime.Parse("15/06/2017 08:30") },
                new News() {  Title = "Connect heads to Malaga to support Caterpillar launch", Content = "Patrick Maloney and Sam Britton, part of our global account team for Caterpillar and Finning, are out in Malaga this week supporting the launch of Cat's new 20 tonne excavator range", Date = DateTime.Parse("10/10/2017 10:30") },
                new News() {  Title = "Connect highlights importance of agency/client relationship", Content = "Midlands-based creative technology agency, Connect, has appointed two new Business Unit Directors, further strengthening its leadership team.", Date = DateTime.Parse("09/10/2017 11:30") },
                new News() {  Title = "Connect shortlisted for Creative Communications & Digital Business of the Year", Content = "The Awards celebrate the success of companies who are putting the region on the map by boosting the economy whilst making a positive contribution to the local community.", Date = DateTime.Parse("28/09/2017 10:30") },
                new News() {  Title = "Are influencers too successful for scandal to damage their business?", Content = "Read Planner, Sophie Beckley's opinion in The Drum ... ", Date = DateTime.Parse("28/09/2017 10:30") },
                new News() {  Title = "Connect helps redefine digital customer service for Birmingham Airport", Content = "Birmingham Airport has today launched a pro-active customer service application for mobile-connected passengers.", Date = DateTime.Parse("27/09/2017 10:30") },
                new News() {  Title = "Report from Frankfurt Motor Show - Die Zukunft ist jetzt", Content = "The automotive market is on the precipice of its most exciting development since Henry Ford started mass production. Technology and the consumer have never had a more important role to play.", Date = DateTime.Parse("18/09/2017 10:30") },
                new News() {  Title = "Why the new GDPR legislation should be a marketer's best friend, not their mortal enemy", Content = "Come 25th May 2018, the new General Data Protection Regulation (GDPR) will be in full swing. We can all grunt and grumble at the prospect of yet another set of rules to follow or, like in life, we can suck it up and get on with it.", Date = DateTime.Parse("23/08/2017 10:30") },
                new News() {  Title = "Want to make an impact?", Content = "We're recruiting. Get in touch. 01902 714 957", Date = DateTime.Parse("19/07/2017 10:30") },
                new News() {  Title = "Top tips for selecting a marketing agency", Content = "There has been a lot of debate recently about in-house vs agency marketing. There is no doubt there are pros and cons to each.", Date = DateTime.Parse("19/07/2017 10:30") },
                new News() {  Title = "Thou shalt not fear difficulty", Content = "It has been speculated that we, as humans, “excuse our sloth under the pretext of difficulty”", Date = DateTime.Parse("29/06/2017 10:30") },
                new News() { Title = "The first foray into agency life for two local graduates", Content = "Last week we welcomed two fantastic graduates into the Connect family. It might have been short but we loved having them and they thoroughly enjoyed their time with us ... ", Date = DateTime.Parse("27/06/2017 10:30") },
                new News() { Title = "Connect is hiring!", Content = "The Midlands' best marketing agency is recruiting.", Date = DateTime.Parse("27/06/2017 10:30") }
               );
        }
    }
}
