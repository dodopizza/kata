using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round4.B
{
    public class Library
    {

        private readonly Dictionary<string, Title> _titles = new Dictionary<string, Title>();

        public Dictionary<String, Title> GetTitles()
        {
            return _titles;
        }

        public void Donate(Title title)
        {
            _titles.Add(title.TitleName, title);
        }

        public List<Title> GetTitlesDonatedByMember(String donorMembershipId)
        {
            Dictionary<string, Title>.ValueCollection allTitles = _titles.Values;
            return allTitles.Where(title => title.DonorId.Equals(donorMembershipId)).ToList();
        }

    }
}
