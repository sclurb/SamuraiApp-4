using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeUI
{
    public static class SpareSamurais
    {

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

        public static Samurai robertLeckie = new Samurai()
        {
            Name = "Robert Leckie",
            Quotes = robertLeckieQuotes
        };
    }
}
