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

        public async Task<IEnumerable<TblDifficultyLevel>> GetAllLevels(int problemsTypeId)
        {
           return await generalDBContext.TblDifficultyLevels.Where(l => l.PronunciationProblemId == problemsTypeId).ToListAsync();
        }

        public async Task<IEnumerable<TblPronunciationProblemsType>> GetAllPronunciationProblemsTypes()
        {
            return await generalDBContext.TblPronunciationProblemsTypes.ToListAsync();
        }
    }
}
