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
            //query.EnlistSamuraiIntoBattleUntracked("John Basilone", "Guadalcanal");
            //query.EnlistSamuraiIntoBattleUntracked("John Basilone", "Iwo Jima");
            //query.EnlistSamuraiIntoBattleUntracked("Merritt Austin Edson", "Tarawa");
            //query.EnlistSamuraiIntoBattleUntracked("Merritt Austin Edson", "Guadalcanal");
            //query.EnlistSamuraiIntoBattleUntracked("Merritt Austin Edson", "Saipan");
            //query.EnlistSamuraiIntoBattleUntracked("Lewis Burwell Puller", "Guadalcanal");
            //query.EnlistSamuraiIntoBattleUntracked("Lewis Burwell Puller", "Peleliu");
            //query.EnlistSamuraiIntoBattleUntracked("Robert Leckie", "Guadalcanal");
            //query.EnlistSamuraiIntoBattleUntracked("Robert Leckie", "Peleliu");

            query.RemoveBattleFromSamurai("John Basilone", "Iwo Jima");
            query.EnlistSamuraiIntoBattleUntracked("John Basilone", "Iwo Jima");


            Console.WriteLine("Hey Dude.");
            

            var result1 = query.GetSamuraiWithBattles("John Basilone");

            foreach (var battle in result1)
            {
                Console.WriteLine($"John Basilone was in this battle {battle.Name}");
            }
            Console.ReadKey();
        }
    }
}
