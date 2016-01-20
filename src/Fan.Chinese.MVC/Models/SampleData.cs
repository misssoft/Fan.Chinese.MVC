using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace Fan.Chinese.MVC.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Topic.Any())
            {
                var topicOne = new Topic() {TopicName = "City", TopicCategory = "Tourism"};
                var topicTwo = new Topic() { TopicName = "Direction", TopicCategory = "Life" };
                var topicThree = new Topic() { TopicName = "Wedding", TopicCategory = "Parties" };

                context.Topic.AddRange(
                    topicOne, topicTwo, topicThree
                    );
                context.SaveChanges();
            }

        }
    }
}
