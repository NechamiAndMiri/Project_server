using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
    public class SpeechTherapistBL: ISpeechTherapistBL
    {
        ISpeechTherapistDL speechTherapistDL;

        public SpeechTherapistBL(ISpeechTherapistDL speechTherapistDL)
        {
            this.speechTherapistDL = speechTherapistDL;
        }
    }
}
