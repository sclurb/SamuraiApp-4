using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SomeUI
{
    public class Seeder
    {

        private SamuraiContext _context = new SamuraiContext();

        private readonly static Battle guadalcanel = new Battle()
        {
            Name = "Guadalcanal",
            StartDate = new DateTime(1942, 08, 07),
            EndDate = new DateTime(1943, 02, 09),
        };
        private readonly static Battle tarawa = new Battle()
        {
            Name = "Tarawa",
            StartDate = new DateTime(1943, 11, 20),
            EndDate = new DateTime(1943, 11, 23)
        };
        private readonly static Battle saipan = new Battle()
        {
            Name = "Saipan",
            StartDate = new DateTime(1944, 06, 15),
            EndDate = new DateTime(1944, 07, 09)
        };

        private readonly static Battle peleliu = new Battle()
        {
            Name = "Peleliu",
            StartDate = new DateTime(1944, 09, 15),
            EndDate = new DateTime(1944, 11, 27)
        };
        private readonly static Battle iwoJima = new Battle()
        {
            Name = "Iwo Jima",
            StartDate = new DateTime(1945, 02, 19),
            EndDate = new DateTime(1945, 03, 26)
        };

        private readonly static Battle okinawa = new Battle()
        {
            Name = "Okinawa",
            StartDate = new DateTime(1945, 03, 26),
            EndDate = new DateTime(1945, 07, 02)
        };



        private readonly static List<Quote> johnBasiloneQuotes = new List<Quote>()
        {
            new Quote()
            {
                Text = "Never fear your enemy, but always respect them"
            },
            new Quote()
            {
                Text = "I'm Staying with my boys."
            },
            new Quote()
            {
                Text = "Anybody who has a feel for automatic weapons knows what I mean. " +
                "You don’t want to be on the wrong side of a poontang-crazed eighteen-year-old " +
                "with a machine gun, that much I know for sure."
            }
        };

        private readonly static List<Quote> robertLeckieQuotes = new List<Quote>()
        {
            new Quote(){ Text = "We have met the enemy and have learned nothing more about him. I have, however, " +
                "l learned some things about myself.  " +
                "There are things men do to one another that are sobering to the soul.   " +
                "It is one thing to reconcile these things with God, but another to square it with yourself"},
            new Quote(){ Text = "Because it is gone you cannot say it will not return; even though you may say " +
                "it has never yet returned-you cannot say that it will not. It is blasphemy to say a bit of metal " +
                "has destroyed life, just as it is presumptuous to say that because life has disappeared it has been " +
                "destroyed. I stood among the heaps of the dead and I knew-no, I felt that death is only a sound we make " +
                "to signify the Thing we do not know."},
            new Quote(){ Text = "Every morning or afternoon, whenever you want to write, you have to go up and shoot that old " +
                "bear under your desk between the eyes."}
        };


        private readonly static List<Quote> chestyQuotes = new List<Quote>()
        {
            new Quote()
            {
                Text = "Where the Hell do you put the bayonet?"
            },
            new Quote()
            {
                Text = "I’ve always believed that no officer’s life, " +
                "regardless of rank, is of such great value to his country " +
                "that he should seek safety in the rear … Officers should be " +
                "forward with their men at the point of impact."
            },
            new Quote()
            {
                Text = "If you want to get the most out of your men, give them a " +
                "break! Don’t make them work completely in the dark. If you do, " +
                "they won’t do a bit more than they have to. But if they comprehend, " +
                "they’ll work like mad."
            }
        };



        private readonly static List<Quote> merrittEdsonQuotes = new List<Quote>()
        {
            new Quote()
            {
                Text = "There it is. It is useless to ask ourselves why it is we who are here. " +
                "We are here. There is only us between the airfield and the Japs. If we don't hold, " +
                "we will loose Guadalcanal."
            },
            new Quote()
            {
                Text = "The only things those people have that you don’t is guts. Do you wanna live forever?"
            },
            new Quote()
            {
                Text = "One hundred rounds do not constitute fire power. One hit constitutes fire power."
            }
        };

        private readonly static Samurai johnBasilone = new Samurai()
        {
            Name = "John Basilone",
            Quotes = johnBasiloneQuotes

        };

        private readonly static Samurai merrittEdson = new Samurai()
        {
            Name = "Merritt Austin Edson",
            Quotes = merrittEdsonQuotes
        };

        private readonly static Samurai lewisBurwellPuller = new Samurai()
        {
            Name = "Lewis Burwell Puller",
            Quotes = chestyQuotes
        };

        private readonly static Samurai robertLeckie = new Samurai()
        {
            Name = "Robert Leckie",
            Quotes = robertLeckieQuotes
        };
        public int numberOfSqlCommandsSaved { get; set; }

        private List<Samurai> samuraiList = new List<Samurai>();
        public Seeder()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            MakeSamuraiList();
            numberOfSqlCommandsSaved = MakeMultipleSamurai(samuraiList);
            numberOfSqlCommandsSaved += MakeBattles();
        } 

        public void MakeSamuraiList()
        {
            samuraiList.Add(merrittEdson);
            samuraiList.Add(lewisBurwellPuller);
            samuraiList.Add(robertLeckie);
            samuraiList.Add(johnBasilone);
        }

        public int MakeMultipleSamurai(List<Samurai> samurais)
        {
            foreach (Samurai sam in samurais)
            {
                _context.Samurais.Add(sam);
            }
            return _context.SaveChanges();
        }

        public int MakeBattles()
        {
            _context.Battles.AddRange(guadalcanel, tarawa, saipan, peleliu, iwoJima, okinawa);

            return _context.SaveChanges();
        }

    }
}
