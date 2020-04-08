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
                InterestType = Interests.Dominos
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
            Interests interestValue;

            List<Clinker> emptyList = new List<Clinker>();

            if (Enum.TryParse(interestString, true, out interestValue))
            {
                //if (Enum.IsDefined(typeof(Interests), interest | interest.ToString().Contains(",")))
                {
                    return _clinkers.Where(clinker => clinker.InterestType == interestValue).ToList(); // could be empty
                }
                //return emptyList;
            }
            else return emptyList;
        }
    }
}
