using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDraft
{
    class Program
    {
        static void Main(string[] args)
        {
            NflDraft draft = new NflDraft();
            draft.InitializePlayers();
            draft.Draft();
        }
    }
}
