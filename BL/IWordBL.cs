using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IWordBL
    {
        Task<List<TblPronunciationProblemsType>> GetAllPronunciationProblemsTypes();
        Task<List<TblDifficultyLevel>> GetAllLevels(int problemsTypeId);
        Task PostLevel(int pronunciationProblemId);
    }
}