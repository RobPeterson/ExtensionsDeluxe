using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension.Dictionary
{
    public interface IDictionaryCollection
    {
        void Initialize();
        bool Exists();
    }
}
