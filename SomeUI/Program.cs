using SamuraiApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SomeUI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        //private static Seeder seeder = new Seeder();
        private static Query query = new Query();

        static void Main(string[] args)

            
        {
            //Console.WriteLine($"The number of Samurais created is: {seeder.numberOfSqlCommandsSaved}");

            //Seeding join entities
            //query.EnlistSamuraiIntoBattleUntracked("John Basilone", "Guadalcanal");
            //query.EnlistSamuraiIntoBattleUntracked("John Basilone", "Iwo Jima");
            //query.EnlistSamuraiIntoBattleUntracked("Merritt Austin Edson", "Tarawa");
            //query.EnlistSamuraiIntoBattleUntracked("Merritt Austin Edson", "Guadalcanal");
            //query.EnlistSamuraiIntoBattleUntracked("Merritt Austin Edson", "Saipan");
            //query.EnlistSamuraiIntoBattleUntracked("Lewis Burwell Puller", "Guadalcanal");
            //query.EnlistSamuraiIntoBattleUntracked("Lewis Burwell Puller", "Peleliu");
            //query.EnlistSamuraiIntoBattleUntracked("Robert Leckie", "Guadalcanal");
            //query.EnlistSamuraiIntoBattleUntracked("Robert Leckie", "Peleliu");
            //query.AddNewSamuraiWithSecretIdentity();
            //query.EnlistSamuraiIntoBattleUntracked("Eugene Bondurant Sledge", "Okinawa");
            //query.EnlistSamuraiIntoBattleUntracked("Eugene Bondurant Sledge", "Peleliu");


            //query.AddSecretIdentityUsingSamuraiName("Lewis Burwell Puller", "Chesty");
            //query.ReplaceSecretIdentity("Lewis Burwell Puller", "Chesty baby");

            //query.RemoveSecretIdentity("Lewis Burwell Puller");

            Console.WriteLine("Hey Dude.");

            //query.AddCreateDateToSamurai("John Basilone");
            //query.AddCreateDateToSamurai("Eugene Bondurant Sledge");
            //query.AddCreateDateToSamurai("Merritt Austin Edson");
            //query.AddCreateDateToSamurai("Robert Leckie");
            //query.AddCreateDateToSamurai("Lewis Burwell Puller");

            query.RemoveSamurai("Robert Leckie");
            query.MakeSamurai(SpareSamurais.robertLeckie);

            var result1 = query.GetSamuraiWithBattles("John Basilone");
            Console.WriteLine("\n-In Bewteen Queries-\n");
            var result2 = query.GetSamuraiWithBattles("Eugene Bondurant Sledge");

            var result3 = query.GetSamuraiWithBattles("Lewis Burwell Puller");

            Console.WriteLine("\n-After Queries-\n");

            Console.WriteLine("------");
            foreach (var battle in result1)
            {
                Console.WriteLine($"\nJohn Basilone was in this battle: {battle.Name}\n");
            }
            Console.WriteLine("------");
            


            foreach (var battle in result2)
            {
                Console.WriteLine($"\nEugene Sledge was in this battle: {battle.Name}\n");
            }
            Console.WriteLine("\nLewis Burwell Puller's secret Identity is: " + query.GetSecretIdentity("Lewis Burwell Puller"));
            foreach (var battle in result3)
            {
                Console.WriteLine($"\nChesty Puller was in this battle: {battle.Name}\n");
            }
            Console.WriteLine("----");
            var result4 =     query.RetrieveSamuraisCreatedInPastWeek();

            var result5 = query.GetSamuraiWithBattles("Robert Leckie");

            foreach (var battle in result5)
            {
                Console.WriteLine($"\nRobert Leckie was in this battle: {battle.Name}\n");
                Console.WriteLine($"Robert Leckie was updated on {battle.SamuraiBattles}");
            }

            Console.ReadKey();
        }
    }
}
