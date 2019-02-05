namespace MVCTraining.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Training.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCTraining.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//Helps with automatic migrations instead of manual ones.
            AutomaticMigrationDataLossAllowed = true; //Bypassing safeguard for data loss. Not usable in production systems.

        }

        protected override void Seed(MVCTraining.Models.ApplicationDbContext context)
        {
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


            context.ItemTypes.AddOrUpdate(p => p.Title, new ItemType
            {
                Title = "Test Item Type 1"
            }, new ItemType
            {
                Title = "Test Item Type 2"
            },
             new ItemType
             {
                 Title = "Test Item Type 3"
             }, new ItemType
             {
                 Title = "Test Item Type 4"
             }
            );


            context.Sections.AddOrUpdate(p => p.Title, new Section
            {
                Title = "Test Section  1"
            }, new Section
            {
                Title = "Test Section  2"
            },
        new Section
        {
            Title = "Test Section  3"
        }, new Section
        {
            Title = "Test Section  4"
        }
       );



            context.Parts.AddOrUpdate(p => p.Title, new Part
            {
                Title = "Test Part  1"
            }, new Part
            {
                Title = "Test Part  2"
            },
        new Part
        {
            Title = "Test Part  3"
        }, new Part
        {
            Title = "Test Part  4"
        }
       );
        }
    }
}
