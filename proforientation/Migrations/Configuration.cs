using System.Collections.Generic;
using System.Linq;
using proforientation.Models;

namespace proforientation.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Professions.Any())
            {
                var professions = new List<Profession>
                {
                    new Profession
                    {
                        Name = "p1",
                        ScoreMin = 5,
                        ScoreMax = 10,
                        ImgUrl = "htpp://",
                        Cost = 55,
                        Description = "Some description here..."
                    },
                    new Profession
                    {
                        Name = "p2",
                        ScoreMin = 11,
                        ScoreMax = 20,
                        ImgUrl = "htpp://",
                        Cost = 100,
                        Description = "Some description here..."
                    },
                    new Profession
                    {
                        Name = "p3",
                        ScoreMin = 21,
                        ScoreMax = 30,
                        ImgUrl = "htpp://",
                        Cost = 200,
                        Description = "Some description here..."
                    }
                };
                professions.ForEach(p => context.Professions.AddOrUpdate(p));
                context.SaveChanges();
            }

            if (!context.Tests.Any())
            {
                var questions = new List<Test>
                {
                    new Test
                    {
                        Question = "q1"
                    },
                    new Test
                    {
                        Question = "q2"
                    },
                    new Test
                    {
                        Question = "q3"
                    },
                    new Test
                    {
                        Question = "q4"
                    },
                    new Test
                    {
                        Question = "q5"
                    }
                };
                questions.ForEach(q => context.Tests.AddOrUpdate(q));
                context.SaveChanges();
            }
            if (!context.Answers.Any())
            {
                var answers = new List<Answer>
                {
                    new Answer
                    {
                        TestId = 1,
                        Name = "a1",
                        ScoreAnswer = 2
                    },
                    new Answer
                    {
                        TestId = 1,
                        Name = "a2",
                        ScoreAnswer = 2
                    },
                    new Answer
                    {
                        TestId = 1,
                        Name = "a3",
                        ScoreAnswer = 5
                    },
                    new Answer
                    {
                        TestId = 2,
                        Name = "a4",
                        ScoreAnswer = 2
                    },
                    new Answer
                    {
                        TestId = 2,
                        Name = "a5",
                        ScoreAnswer = 2
                    },
                    new Answer
                    {
                        TestId = 2,
                        Name = "a6",
                        ScoreAnswer = 5
                    },
                    new Answer
                    {
                        TestId = 3,
                        Name = "a7",
                        ScoreAnswer = 2
                    },
                    new Answer
                    {
                        TestId = 3,
                        Name = "a8",
                        ScoreAnswer = 2
                    },
                    new Answer
                    {
                        TestId = 3,
                        Name = "a9",
                        ScoreAnswer = 5
                    },
                    new Answer
                    {
                        TestId = 4,
                        Name = "a10",
                        ScoreAnswer = 2
                    },
                    new Answer
                    {
                        TestId = 4,
                        Name = "a11",
                        ScoreAnswer = 2
                    },
                    new Answer
                    {
                        TestId = 4,
                        Name = "a12",
                        ScoreAnswer = 5
                    },
                    new Answer
                    {
                        TestId = 5,
                        Name = "a13",
                        ScoreAnswer = 2
                    },
                    new Answer
                    {
                        TestId = 5,
                        Name = "a14",
                        ScoreAnswer = 2
                    },
                    new Answer
                    {
                        TestId = 5,
                        Name = "a15",
                        ScoreAnswer = 5
                    }
                };
                answers.ForEach(a => context.Answers.AddOrUpdate(a));
                context.SaveChanges();
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
