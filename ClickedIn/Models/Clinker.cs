﻿using System;
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

    public class Interests
    {
        public string Name { get; set; }
    }
    public class Clinker
    {
        public int Id { get; set; }
        public string HoodName { get; set; }
        public Services ServiceType { get; set; }
        public List<Interests> Interests { get; set; }
        public List<Clinker> Homies { get; set; }
        public List<Clinker> Enemies { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
