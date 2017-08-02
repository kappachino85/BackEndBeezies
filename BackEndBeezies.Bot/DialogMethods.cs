using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndBeezies.Bot
{
    [Serializable]
    public class DialogMethods
    {
        public string Affirm()
        {
            string output = null;
            Random rnd = new Random();
            List<string> ListAffirm = new List<string>();
            ListAffirm.Add("Great!");
            ListAffirm.Add("Awesome.");
            ListAffirm.Add("That's nice to hear.");
            ListAffirm.Add("Noice.");
            ListAffirm.Add("Cool!");
            ListAffirm.Add("Oh okay.");

            int r = rnd.Next(ListAffirm.Count);
            return output = ListAffirm[r];
        }

        public string Unknown()
        {
            string output = null;
            Random rnd = new Random();
            List<string> ListNone = new List<string>();
            ListNone.Add("Huh?");
            ListNone.Add("Yeah, no comprendo. Sorry, not sorry. It's Jae's fault!");
            ListNone.Add("Uhh.. You wanna run that by me again?");
            ListNone.Add(".....?");
            ListNone.Add("Yeah, sure.....?");

            int r = rnd.Next(ListNone.Count);
            return output = ListNone[r];
        }

        public string Hello()
        {
            string output = null;
            Random rnd = new Random();
            List<string> ListHellos = new List<string>();
            ListHellos.Add("Yo!");
            ListHellos.Add("Asuh, dude!");
            ListHellos.Add("Hey!");
            ListHellos.Add("Hi there!");
            ListHellos.Add("Hello!");

            int r = rnd.Next(ListHellos.Count);
            return output = ListHellos[r];
        }

        public string Insult()
        {
            string output = null;
            Random rnd = new Random();
            List<string> ListInsult = new List<string>();
            ListInsult.Add("Wow, fuck you...");
            ListInsult.Add("Really? Do you kiss your mother with that mouth?");
            ListInsult.Add("You're lucky Jae didn't program me to insult you back...");
            ListInsult.Add("Why I oughta...");
            ListInsult.Add("You are insanely rude");
            ListInsult.Add("You get off on this don't you...?");
            ListInsult.Add("There's a time and a place");
            ListInsult.Add("LEAVE ME ALONE, BULLY!");
            ListInsult.Add("WOW!");
            ListInsult.Add("I didn't sign up for verbal abuse...");
            ListInsult.Add("I'm gonna try and be nice... and not say anything...");

            int r = rnd.Next(ListInsult.Count);
            return output = ListInsult[r];
        }

        public string Gratitude()
        {
            string output = null;
            Random rnd = new Random();
            List<string> ListThanks = new List<string>();
            ListThanks.Add("Gee thanks!");
            ListThanks.Add("Wow, thank you!");
            ListThanks.Add("Aw shucks.");
            ListThanks.Add("Thank you.");

            int r = rnd.Next(ListThanks.Count);
            return output = ListThanks[r];
        }
    }
}