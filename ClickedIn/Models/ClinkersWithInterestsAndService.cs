using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickedIn.Models
{
    public class ClinkersWithInterestsAndService
    {
        public int ClinkerId { get; set; }
        public string HoodName { get; set; }
        public List<string> Interests { get; set; }
        public string Service { get; set; }
    }
}
