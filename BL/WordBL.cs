using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class WordBL: IWordBL
    {
        IWordDL wordDL;

        public WordBL(IWordDL wordDL)
        {
            this.wordDL = wordDL;
        }
    }
}
