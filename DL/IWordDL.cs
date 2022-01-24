using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IWordDL
    {
        Task<List<TblPronunciationProblemsType>> GetAllPronunciationProblemsTypes();
        Task<List<TblDifficultyLevel>> GetAllLevels(int problemsTypeId);
    }
}