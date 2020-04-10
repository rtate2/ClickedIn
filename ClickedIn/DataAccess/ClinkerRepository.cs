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
                }
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

        public List<Clinker> AddHomies(Clinker homieToAdd)
        {
            List<Clinker> homies = new List<Clinker>();
            homies.Add(homieToAdd);
            return homies;
        }

        public List<Clinker> AddEnemy(Clinker enemyToAdd)
        {
            List<Clinker> enemies = new List<Clinker>();
            enemies.Add(enemyToAdd);
            return enemies;
        }
    }
}
