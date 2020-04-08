using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickedIn.Models
{
    public enum Services {
        Smuggling,
        HitMan,
        Escapee,
        Tattooist,
        Barber,
        Cook,
        PlayMate,
        Thief,
        Snitch,
        Negotiator
    }

    public enum Interests
    {
        WeightLifting,
        Basketball,
        Dominos,
        Library,
        Fighting,
        Writing,
        Gambling,
        Cards,
        StoryTelling,
        Spitting,
        Confinement
    }
    public class Clinker
    {
        public int Id { get; set; }
        public string HoodName { get; set; }
        public Services ServiceType { get; set; }
        public Interests InterestType { get; set; }
    }
}
