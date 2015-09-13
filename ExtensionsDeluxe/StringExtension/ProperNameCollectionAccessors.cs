using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public partial class ProperNameCollection
    {
        /* This will return true if it is a known given name; false otherwise. */
        public bool IsGivenName(string name)
        {
            return givenNames.Contains(name.ToUpper());
        }

        /* This will return true if it is a known surname; false otherwise. */
        public bool IsSurname(string name)
        {
            return this.surnames.Contains(name.ToUpper());
        }
    }
}
