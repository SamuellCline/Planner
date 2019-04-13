using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Planner.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PlannerContext>>()))
            {
               
                if (context.Plan.Any())
                {
                    return;   // DB has been seeded
                }

                context.Plan.AddRange(
                    new Plan
                    {
                        
                        Date = DateTime.Parse("1989-2-12"),
                        Theme = "Restoration",
                        OpeningSong = 7,
                        OpeningPrayer = "Person 1",
                        Conducting = "Bishop",
                        SacramentHymn = 193,
                        Speaker1 = "Person 2",
                        TalkTopic1 = "Book of Mormon",
                        Speaker2 = "Person 3",
                        TalkTopic2 = "Prieshood Keys",
                        ClosingSong = 305,
                        ClosingPrayer = "Person 9"
                       
                        

                    }
                    
                    
                );
                context.SaveChanges();
            }
        }
    }
}