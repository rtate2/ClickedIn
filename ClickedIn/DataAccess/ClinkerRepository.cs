using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickedIn.Models;
using Dapper;
using Microsoft.Data.SqlClient;


namespace ClickedIn.DataAccess
{
    public class ClinkerRepository
    {
        const string ConnectionString = "Server=localhost;Database=ClinkedIn;Trusted_Connection=True;";

        static List<Clinker> _clinkers = new List<Clinker>()
        {
            new Clinker
            {
                Id = 1,
                HoodName = "June Bug",
                ServiceType = Services.Cook,
                Interests = new List<Interests>()
                {
                    new Interests
                    {
                        Name = "Dominos"
                    },
                    new Interests
                    {
                        Name = "Basketball"
                    }
                },
                Homies = new List<Clinker>(),
                Enemies = new List<Clinker>(),
                ReleaseDate = new DateTime(2020,12,10)
            },
            new Clinker
            {
                Id = 2,
                HoodName = "Lil Ray",
                ServiceType = Services.Snitch,
                Interests = new List<Interests>()
                {
                    new Interests
                    {
                        Name = "Cooking"
                    },
                    new Interests
                    {
                        Name = "Basketball"
                    }
                },
                Homies = new List<Clinker>(),
                Enemies = new List<Clinker>(),
                ReleaseDate = new DateTime(2022,1,5)
            },
            new Clinker
            {
                Id = 3,
                HoodName = "Lil Randy",
                ServiceType = Services.Negotiator,
                Interests = new List<Interests>()
                {
                    new Interests
                    {
                        Name = "Sleeping"
                    },
                    new Interests
                    {
                        Name = "Cooking"
                    }
                },
                Homies = new List<Clinker>(),
                Enemies = new List<Clinker>(),
                ReleaseDate = new DateTime(2042,12,31)
            },
             new Clinker
            {
                Id = 4,
                HoodName = "Lil Kel",
                ServiceType = Services.Thief,
                Interests = new List<Interests>()
                {
                    new Interests
                    {
                        Name = "Sleeping"
                    },
                    new Interests
                    {
                        Name = "Sneaking"
                    }
                },
                Homies = new List<Clinker>(),
                Enemies = new List<Clinker>(),
                ReleaseDate = new DateTime(2020,8,7)
            },
              new Clinker
            {
                Id = 5,
                HoodName = "Lil Mo",
                ServiceType = Services.Snitch,
                Interests = new List<Interests>()
                {
                    new Interests
                    {
                        Name = "Eating"
                    },
                    new Interests
                    {
                        Name = "Money"
                    }
                },
                Homies = new List<Clinker>(),
                Enemies = new List<Clinker>(),
                ReleaseDate = new DateTime(2020,4,24)
            }
        };

        public void AddClinker(Clinker clinker)
        {
            clinker.Id = _clinkers.Max(x => x.Id) + 1;
            _clinkers.Add(clinker);
        }

        public List<Clinker> GetClinkers()
        {
            //return _clinkers;
            var sql = @"select HoodName
                        from Clinker";

            using (var db = new SqlConnection(ConnectionString)) 
            {
                return db.Query<Clinker>(sql).ToList();
            }
        }

        public List<ClinkersWithInterestsAndService> GetClinkersWithInterestsAndService()
        {
            var sql = @"select Clinker.HoodName, [Service].[Type] as [Service], [Service].ClinkerId
                        from Service
	                        join Clinker
		                        on Service.ClinkerId = Clinker.Id";

            var interestSql = @"select [Type] as InterestType, Interest.ClinkerId
                                from Interest";

            using (var db = new SqlConnection(ConnectionString))
            {
                var results = db.Query<ClinkersWithInterestsAndService>(sql).ToList();
                var interests = db.Query<Interest>(interestSql).ToList();

                foreach (var result in results)
                {
                    result.Interests = interests.Where(i => i.ClinkerId == result.ClinkerId).Select(i => i.InterestType).ToList();
                }

                return results;
            }
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

        public Clinker UpdateInterests(int clinkerId, string clinkerInterest, string AddOrRemove)
        {
            Interests i = new Interests
            {
                Name = clinkerInterest
            };
            var clinker = GetClinkerById(clinkerId);
            if (AddOrRemove.ToLower() == "add")
            {
                clinker.Interests.Add(i);
                return clinker;
            }
            else if (AddOrRemove.ToLower() == "remove")
            {
                var foundInterest = clinker.Interests.Find(interest => interest.Name == clinkerInterest);
                clinker.Interests.Remove(foundInterest);
                return clinker;
            }
            return clinker;
        }

        public Clinker UpdateService(int clinkerId, string clinkerService)
        {
            Services serviceValue;

            var clinker = GetClinkerById(clinkerId);

            if (Enum.TryParse(clinkerService, true, out serviceValue))
            {
                clinker.ServiceType = serviceValue;
                return clinker;
            }
            return clinker;
        }

        public int RemainingSentence(int clinkerId)
        {
            var clinker = GetClinkerById(clinkerId);
            var clinkerReleaseDate = clinker.ReleaseDate;
            DateTime today = DateTime.Today;
            var daysRemaining = (clinkerReleaseDate - today).Days;
            return daysRemaining;
        }
    }
}
