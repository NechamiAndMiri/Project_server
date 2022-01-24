using DL;
using Entities;
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

        public async Task<IEnumerable<TblDifficultyLevel>> GetAllLevels(int problemsTypeId)
        {
            return await wordDL.GetAllLevels(problemsTypeId);
        }

        public async Task<IEnumerable<TblPronunciationProblemsType>> GetAllPronunciationProblemsTypes()
        {
            return await wordDL.GetAllPronunciationProblemsTypes();
        }

        public Task PostLevel(int pronunciationProblemId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TblWord>> GetAllWords(int levelId)
        {
            return await wordDL.GetAllWords(levelId);
        }
    }
}
