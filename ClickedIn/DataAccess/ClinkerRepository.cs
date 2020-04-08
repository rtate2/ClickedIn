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
                Interests = Interests.Dominos
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

        public List<Clinker> GetClinkerByInterest(string Interest)
        {
            Interests interest;
            
            if (Enum.TryParse(Interest, true, out interest))
            {
                if (Enum.IsDefined(typeof(Interests), interest) | interest.ToString().Contains(","))
                {
                    var filteredClinkers = _clinkers.Where(clinker => clinker.Interests == interest);
                }
            }
            return "didn't work";
        }
    }
}
