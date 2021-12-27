using Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<TblWord>> GetAllWords(int levelId)
        {
            return await generalDBContext.TblWords.Where(w=>w.DifficultyLevelId==levelId).ToListAsync();
        }
    }
}
