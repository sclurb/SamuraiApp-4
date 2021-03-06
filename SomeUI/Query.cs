﻿using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeUI
{
    public class Query
    {
        private SamuraiContext _context = new SamuraiContext();

        public Query()
        {

        }


        public int RemoveSamurai(string name)
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);
            _context.Remove(samurai);
            return _context.SaveChanges();
        }

        public int MakeSamurai(Samurai samurai)
        {
            _context.Samurais.Add(samurai);
            return _context.SaveChanges();
        }

        public List<Samurai> RetrieveSamuraisCreatedInPastWeek()
        {
            var oneweekago = DateTime.Now.AddMinutes(-15);
            var samurais = _context.Samurais
                .Where(s => EF.Property<DateTime>(s, "Created") >= oneweekago)
                .Include(q => q.Quotes)
                .ToList();
            return samurais;

            //var samurais = _context.Samurais
            //    .Where(s => EF.Property<DateTime>(s, "Created") >= oneweekago)
            //    .Select(s => new { s.Id, s.Name, Created=EF.Property<DateTime>(s, "Created")})
            //    .ToList();
            //return samurais;
        }

        public int CreateSamurai(string name)
        {
            var samurai = new Samurai { Name = name };
            _context.Samurais.Add(samurai);
            var timestamp = DateTime.Now;
            _context.Entry(samurai).Property("Created").CurrentValue = timestamp;
            _context.Entry(samurai).Property("LastModified").CurrentValue = timestamp;
           return  _context.SaveChanges();
        }

        public int AddCreateDateToSamurai(string name)
        {
            var samurai = _context.Samurais.FirstOrDefault(sa => sa.Name == name);
            //_context.Samurais.Add(samurai);
            var timestamp = DateTime.Now;
            _context.Entry(samurai).Property("Created").CurrentValue = timestamp;
            _context.Entry(samurai).Property("LastModified").CurrentValue = timestamp;
            return _context.SaveChanges();
        }

        public int RemoveBattleFromSamurai(string samuraiName, string battleName)
        {
            Samurai samuraiWithBattles;
            SamuraiBattle battle;
            samuraiWithBattles = _context.Samurais.Where(s => s.Name == samuraiName)
                .Include(sb => sb.SamuraiBattles)
                .ThenInclude(b => b.Battle).FirstOrDefault();
            battle = samuraiWithBattles.SamuraiBattles.SingleOrDefault(sb => sb.Battle.Name == battleName);
            samuraiWithBattles.SamuraiBattles.Remove(battle);
            _context.ChangeTracker.DetectChanges();

            return _context.SaveChanges();
        }

        public int AddSecretIdentityUsingSamuraiName(string samuraiName, string realIdentity)
        {
            var samurai = _context.Samurais.Where(s => s.Name == samuraiName);
            var id = samurai.Select(s => s.Id).FirstOrDefault();
            var identity = new SecretIdentity { SamuraiId = id, RealName = realIdentity };
            _context.Add(identity);
            return _context.SaveChanges();
        }

        public int ReplaceSecretIdentity(string samuraiName, string newIdentity)
        {
            var samurai = _context.Samurais.Where(s => s.Name == samuraiName)
                .Include(si=> si.SecretIdentity);

            var identity = samurai.Select(si => si.SecretIdentity).FirstOrDefault();
            identity.RealName = newIdentity;
            _context.Update(identity);

            return _context.SaveChanges();
        }

        public int RemoveSecretIdentity(string samuraiName)
        {
            var samurai = _context.Samurais.Where(s => s.Name == samuraiName)
                .Include(si => si.SecretIdentity);

            var identity = samurai.Select(si => si.SecretIdentity).FirstOrDefault();
            _context.Remove(identity);

            return _context.SaveChanges();
        }


        public int EnlistSamuraiIntoBattleUntracked(string samuraiName, string battleName)
        {
            Samurai samurai;
            Battle battle;
            using (var separateOpertaion = new SamuraiContext())
            {
                samurai = separateOpertaion.Samurais.Where(s => s.Name == samuraiName).FirstOrDefault();
                battle = separateOpertaion.Battles.Where(b => b.Name == battleName).FirstOrDefault();
                battle.SamuraiBattles.Add(new SamuraiBattle { SamuraiId = samurai.Id });
                separateOpertaion.Battles.Attach(battle);
                separateOpertaion.ChangeTracker.DetectChanges(); // here will show debug information.
                return separateOpertaion.SaveChanges();
            }
        }

        public List<Battle> GetSamuraiWithBattles(string samuraiName)
        {
            var samuraiWithBattles = _context.Samurais
                .Include(s => s.SamuraiBattles)
                .ThenInclude(b => b.Battle)
                .FirstOrDefault(sb => sb.Name == samuraiName);
            var allTheBattles = new List<Battle>();
            foreach (var battle in samuraiWithBattles.SamuraiBattles)
            {
                allTheBattles.Add(battle.Battle);
            }
            return allTheBattles;
        }

        public string GetSecretIdentity(string name)
        {
            var samurai = _context.Samurais.Include(si => si.SecretIdentity).FirstOrDefault(s => s.Name == name);
            return samurai.SecretIdentity.RealName.ToString();
        }

        public int AddNewSamuraiWithSecretIdentity()
        {
            var quotes = new List<Quote>()
            {
                new Quote
                {
                    Text = "The Japanese fought to win - it was a savage, brutal," +
                    " inhumane, exhausting and dirty business."
                },
                new Quote
                {
                    Text = "Your soul may belong to Jesus, but your ass belongs to the marines."
                }
            };
            var samurai = new Samurai { Name = "Eugene Bondurant Sledge" };
            samurai.SecretIdentity = new SecretIdentity { RealName = "Sledge" };
            _context.Add(samurai);
            return _context.SaveChanges();
        }
    }
}
