using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickedIn.Models;


namespace ClickedIn.DataAccess
{
    public class ClinkerRepository
    {
        static List<Clinker> _clinkers = new List<Clinker>()
        {
            new Clinker
            {
                Id = 1,
                HoodName = "June Bug",
                ServiceType = Services.Cook,
                Interests = new List<Interest>()
                {
                    new Interest
                    {
                        Name = "Dominos"
                    },
                    new Interest
                    {
                        Name = "Basketball"
                    }
                },
                Homies = new List<Clinker>(),
                Enemies = new List<Clinker>()
            },
            new Clinker
            {
                Id = 2,
                HoodName = "Lil Ray",
                ServiceType = Services.Snitch,
                Interests = new List<Interest>()
                {
                    new Interest
                    {
                        Name = "Cooking"
                    },
                    new Interest
                    {
                        Name = "Basketball"
                    }
                },
                Homies = new List<Clinker>(),
                Enemies = new List<Clinker>()
            },
            new Clinker
            {
                Id = 3,
                HoodName = "Lil Randy",
                ServiceType = Services.Negotiator,
                Interests = new List<Interest>()
                {
                    new Interest
                    {
                        Name = "Sleeping"
                    },
                    new Interest
                    {
                        Name = "Cooking"
                    }
                },
                Homies = new List<Clinker>(),
                Enemies = new List<Clinker>()
            }
        };

        public void AddClinker(Clinker clinker)
        {
            clinker.Id = _clinkers.Max(x => x.Id) + 1;
            _clinkers.Add(clinker);
        }

        public List<Clinker> GetClinkers()
        {
            return _clinkers;
        }

        public List<Clinker> GetClinkersByInterest(string interestString)
        {
            List<Clinker> filteredList = new List<Clinker>();

            foreach (var clinker in _clinkers)
            {
                var hasRelatedInterests = clinker.Interests.Any(interest => interest.Name == interestString);
                if (hasRelatedInterests)
                {
                    filteredList.Add(clinker);
                }
            }
            return filteredList;
        }

        public List<Clinker> GetClinkersByServices(string serviceString)
        {
            Services serviceValue; 

            List<Clinker> emptyList = new List<Clinker>();

            if (Enum.TryParse(serviceString, true, out serviceValue))
            {
                return _clinkers.Where(clinker => clinker.ServiceType == serviceValue).ToList(); // could be empty
            }
            else return emptyList;
        }

        public Clinker GetClinkerById (int clinkerId)
        {
            var clinker = _clinkers.FirstOrDefault(clinker => clinker.Id == clinkerId);
            return clinker;
        }

        public Clinker AddHomies(int clinkerId, int homieId)
        {
            var clinker = GetClinkerById(clinkerId);
            var homie = GetClinkerById(homieId);
            clinker.Homies.Add(homie);
            return clinker;
        }

        public Clinker AddEnemy(int clinkerId, int enemyId)
        {
            var clinker = GetClinkerById(clinkerId);
            var enemy = GetClinkerById(enemyId);
            clinker.Enemies.Add(enemy);
            return clinker;
        }
    }
}
