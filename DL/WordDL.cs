using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class WordDL : IWordDL
    {
        GeneralDBContext generalDBContext;
        public WordDL()     
        {
            generalDBContext = new GeneralDBContext();
        }
        public Task<IEnumerable<TblPronunciationProblemsType>> GetAllPronunciationProblemsTypes()
        {
            return null;// await generalDBContext.TblMessages.Where(m => m.Patient.SpeechTherapistId == speechTherapistID).ToListAsync();
        }
    }
}
